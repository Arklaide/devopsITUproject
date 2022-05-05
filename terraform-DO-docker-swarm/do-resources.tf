variable "do_token" {
  type = string
}

variable "public_ssh_key_location" {
  type = string
}

variable "private_ssh_key_location" {
  type = string
}

terraform {
  required_providers {
    digitalocean = {
      source = "digitalocean/digitalocean"
    }
  }
}

provider "digitalocean" {
  token = var.do_token
}

resource "digitalocean_ssh_key" "default" {
  name       = "swarm-ssh"
  public_key = file(var.public_ssh_key_location)
}

resource "digitalocean_droplet" "swarm_manager" {
  image    = "ubuntu-20-04-x64"
  name     = "swarm-manager-1"
  region   = "fra1"
  size     = "s-1vcpu-1gb"
  ssh_keys = [digitalocean_ssh_key.default.fingerprint]

  connection {
    user        = "root"
    type        = "ssh"
    host = self.ipv4_address
    private_key = file(var.private_ssh_key_location)
  }

  provisioner "file" {
    source      = "../docker-compose.production.yml"
    destination = "/root/docker-compose.production.yml"
  }

  provisioner "file" {
    source      = "../.env"
    destination = "/root/.env"
  }
  provisioner "file" {
    source      = "../prometheus.yml"
    destination = "/root/prometheus.yml"
  }

    provisioner "remote-exec" {
    inline = [
        "apt-get update",
        "snap install doctl",
        "mkdir ~/.config",
        "snap connect doctl:dot-docker",
        "doctl auth init -t ${var.do_token}",
        "doctl registry login",
    ]
}

  provisioner "remote-exec" {
    scripts = [
      "scripts/docker-install.sh",
      "scripts/start-swarm.sh"
    ]
  }

  provisioner "local-exec" {
    command = "ssh -i ${var.private_ssh_key_location} -o StrictHostKeyChecking=no -o UserKnownHostsFile=/dev/null root@${self.ipv4_address} 'docker swarm join-token -q worker' > token.txt"
  }
}

resource "digitalocean_droplet" "swarm_worker" {
  image    = "ubuntu-20-04-x64"
  name     = "swarm-worker-1"
  region   = "fra1"
  size     = "s-1vcpu-1gb"
  ssh_keys = [digitalocean_ssh_key.default.fingerprint]

  connection {
    user        = "root"
    type        = "ssh"
    host = self.ipv4_address
    private_key = file(var.private_ssh_key_location)
  }

  provisioner "remote-exec" {
    inline = [
        "apt-get update",
    ]
}

   provisioner "remote-exec" {
    scripts = [
       "scripts/docker-install.sh",
    ]
  }

provisioner "local-exec" {
    command = "ssh -i ${var.private_ssh_key_location} -o StrictHostKeyChecking=no -o UserKnownHostsFile=/dev/null root@${self.ipv4_address} 'docker swarm join --token ${trimspace(file("token.txt"))} ${digitalocean_droplet.swarm_manager.ipv4_address_private}:2377'"
  }
#   provisioner "remote-exec" {
#     inline = [
#       "docker swarm join --token ${trimspace(file("token.txt"))} ${digitalocean_droplet.swarm_manager.ipv4_address_private}:2377"
#     ]
#   }
  provisioner "local-exec" {
    command = "ssh -i ${var.private_ssh_key_location} -o StrictHostKeyChecking=no -o UserKnownHostsFile=/dev/null root@${digitalocean_droplet.swarm_manager.ipv4_address} 'docker stack deploy --compose-file docker-compose.production.yml --with-registry-auth minitwitswarm'"
  }
}

output "swarm_manager_ip" {
  value = digitalocean_droplet.swarm_manager.ipv4_address
}

output "swarm_worker_ip" {
  value = digitalocean_droplet.swarm_worker.ipv4_address
}