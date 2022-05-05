# How to use this terraform project with Linux

- Follow the instruction in 'terraform.tfvars.example'
- create an empty file token.txt in the project folder
- Init terraform project by 'terraform init'
- Ensure everything is correct by 'terraform plan'
- Apply terraform project by 'terraform apply -var-file=terraform.tfvars --auto-approve'
- Destroy if needed by 'terraform destroy -var-file=terraform.tfvars --auto-approve'

## Notes

- Be sure to update the static URL in the dotnet code in order for the new IP to work
- It could be a good idea to add our digital ocean project, such that it does not go to the default.
  - e.g. with 'digitalocean_project_resources'
