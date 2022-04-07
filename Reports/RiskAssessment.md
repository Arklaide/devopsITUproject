# Security analysis

## Risk Assessment

### Risk Identification

There are 4 main assets in our ecosystem, which are listed in the table below:

| No  | Assets                                          |
| --- | ----------------------------------------------- |
| 1   | Database                                        |
| 2   | Web application frontend                        |
| 3   | Web API                                         |
| 4   | Server hosting asset 2, 3, and other containers |

The assets no. 2 & 3 is run in docker containers on the same server, asset no 4. However, there are more containers which interacts with them, these are listed below:

- Monitoring
  - Grafana
  - Prometheus
- Logging
  - Elastic search
  - Kibana

For each assets there are multiple threat sources and risk scenarios associated, the table below shows the most interesting:

| Risk No | Asset | Threat source                                         | Risk scenario                                                                                                                           |
| ------- | ----- | ----------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| 1       | 2     | SQL injection                                         | An adversary can sign up, log in, create tweets in input fields to inflict damage to the ecosystem                                      |
| 2       | 3     | Interception                                          | The data from asset 2 is sent to the API, an adversary can intercept the request and alter the data                                     |
| 3       | All   | Intrusion                                             | An adversary can obtain access through unsecured credentials, ports, etc. E.g. a developers pushed credentials to the public repository |
| 4       | 4     | Access to hosted services                             | An adversary can find open ports on the server and access services like kibana and read the logs without credentials                    |
| 5       | All   | Outdated dependency, package, and/or software version | An adversary can exploit known vulnerabilities of outdated software                                                                     |
| 6       | 2     | Broken access control                                 | An adversary can act as another user to manipulate the user's data                                                                      |

### Risk Analysis

We use the likelihood and impact definitions as defined by TODO: insert security book ref. The risk is found by looking at the likelihood and impact matrix as defined below:
| Risk level | | | |
|---|---|---|---|
| Likelihood | | Impact |  
| | Low | Medium | High |
| High | Low| Medium | High |
| Medium | Low | Medium | Medium |
| Low | Low | Low | Low|

| Risk No | Likelihood | Impact | Risk   |
| ------- | ---------- | ------ | ------ |
| 1       | Low        | High   | Low    |
| 2       | High       | High   | High   |
| 3       | Medium     | High   | Medium |
| 4       | High       | Medium | Medium |
| 5       | Low        | High   | Low    |
| 6       | Medium     | Low    | Low    |

| Risk No | Counter measure                                                                                                                                                                                                                                                                        |
| ------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1       | Validate and sanitize all user input in asset 2 and validate data sent from asset 2 in asset 3 before accessing the database.                                                                                                                                                          |
| 2       | Enforce the use of HTTPS and ensure transfer data is encrypted.                                                                                                                                                                                                                        |
| 3       | Conduct training for team members to ensure security is enforced such as keeping secrets in a manager or in a local environment file. Furthermore, third party entities need to be checked before use. Furthermore, developers should not open unneccesary ports to the outside world. |
| 4       | There are services which have their ports open to the outside world for easy access for the team. However, these services needs to be secured with safe credentials. Services like Kibana.                                                                                             |
| 5       | Regularly check vulnerabilities of the ecosystem's dependencies. Update versions if needed and use tools such as Snyk to look for vulnerabilities.                                                                                                                                     |
| 6       | Users should not be able to identify as others and should only be able to access data belonging to them. The requests should enforce you can't change your own user to e.g. another ID and the code should check if this specific user has access to requested data.                   |

## Continous security checks

The GitHub repository has Snyk enabled to run regularly security assessment checks as well when creating pull requests. Snyk is a security platform, which we use to find vulnerabilities in our systems. This is also integrated in our contionous integration pipeline for the docker images we create.

Snyk has found the following issuses:

- CVE-2022-28391 - Affecting our Alpine busybox version for our blazor app
- The package DotNetEnv@2.3.0 for our API uses some dependencies which are vulnerable
- Some encoding seems vulnerable in our system

## Penetration test

### Results

### Actions

### Status of logging and monitoring

Can we see the pen test in the logs, if not, our logging is a vulnerability, since we can detect attacks (see owasp top ten)
