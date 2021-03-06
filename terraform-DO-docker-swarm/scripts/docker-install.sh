#!/bin/bash

# Install Docker
yes | apt install docker.io

# Configure firewall to enable Docker Swarm ports
yes | ufw enable

ufw allow 22/tcp
ufw allow 2376/tcp
ufw allow 2377/tcp
ufw allow 7946/tcp
ufw allow 7946/udp
ufw allow 4789/udp
ufw allow 8080/tcp

ufw reload


