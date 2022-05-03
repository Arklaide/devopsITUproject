# Incident log

## Lost access to our first single server

The group lost access to the first server of the project. It was no longer possible to log in via SSH-keys or in the DigitalOcean UI. The server was put in recovery mode, but access was still not possible to obtain even when resetting root password. The solution was to quickly deploy new servers, but now with two machines using Docker Swarm. The downtime was about 4 hours mostly due to creating a better setup with Docker Swarm and little manual configuration of the servers. It was not possible to find any suspicious activity, moreover, there was no extra load on CPU or other metrics of the server, which could have indicated someone had installed a BitCoin miner. The old server was later destroyed.

### Details

| Item                        | Description           |
| --------------------------- | --------------------- |
| Incident date and time      | unknown               |
| Discovered date and time    | 2022-04-19 09:00 CEST |
| Fixed date and time         | 2022-04-19 14:00 CEST |
| Type of incident            | loss of server access |
| Affected server IP          | 68.183.67.47          |
| Suspicious activities found | none                  |
| Discover                    | crie                  |
| Extra personnel involved    | dant                  |

### Root cause, resolution and recovery

There was a fair amount of investigation into resolving the incident, however the root cause was never found. Unfortunately, the group did not take a snapshot of the current state of the server before investigation begun. A snapshot would have prevented that docker volumes would have been lost, since the investigation corrupted the mount/drive.

#### Recovery steps

- Log in via normal SSH-key
  - Yielded "Permission denied, please try again"
- Trying to enable ssh password authentication to log in with a new root password generated in the DigitalOcean UI
  - It was already enabled due to one of the CI/CD pipeline GitHub actions could not work without it. However, this root password was only stored in GitHub secrets, thus a speculation could be a GitHub action leak of the password, but this is highly unlikely.
  - This was not a success and yielded "Login incorrect" when trying to login with ssh root password
- Mounting and using a block storage volume to dig into the drive data
  - This did not give any useful information and ultimately lead to the storage to be corrupted
  - The error message yielded was "error: file '/boot/grub/i386-pc/normal.mod not found'. This was due to the filesystem changing when trying to mount and it was unsuccessful to revert and find the correct mount
- Switching between ISO recovery mode and normal hard
  drive boot to find and fix potential issues
  - This was not a success

### Corrective and preventive measures

Since the root cause was never found it is hard to suggest measures. However, one way to quickly deploy without manual configuration on the servers would be to enable infrastructure as code in the project. Using a software tool as Terraform would allow us to automate the creation of docker swarm and servers leading to less downtime. The only issue is the local docker volumes, which are lost. However, storing the volumes else where could be a preventive measure for loss of logging and monitoring data.

#### Extra measures

- Ensuring only SSH-keys are used, updating our CI/CD pipeline GitHub actions to not use SSH password.
