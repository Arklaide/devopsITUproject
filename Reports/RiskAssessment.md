# Risk Assessment

## Risk Identification

There are 3 main assets in our ecosystem, which are listed in the table below:

| No  | Assets                                          |
| --- | ----------------------------------------------- |
| 1   | Database                                        |
| 2   | Web application frontend                        |
| 3   | Web API                                         |
| 4   | Server hosting asset 2, 3, and other containers |

The assets no. 2 & 3 is run in docker containers on the same server, asset no 4. However, there are more containers which interacts which them, these are listed below:

- Monitoring
  - Grafana
  - Prometheus
- Logging
  - Elastic search
  - Kibana

For each assets there are multiple threat sources and risk scenarios associated, the table below shows the most interesting:

| Risk No | Asset | Threat source             | Risk scenario                                                                                                                           |
| ------- | ----- | ------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| 1       | 2     | SQL injection             | An adversary can sign up, log in, create tweets in input fields to inflict damage to the ecosystem                                      |
| 2       | 3     | Interception              | The data from asset 2 is sent to the API, an adversary can intercept the request and alter the data                                     |
| 3       | All   | Intrusion                 | An adversary can obtain access through unsecured credentials, ports, etc. E.g. a developers pushed credentials to the public repository |
| 4       | 4     | Access to hosted services | An adversary can find open ports on the server and access services like kibana and read the logs without credentials                    |

### Assets

Database

- user info

- twits

Server/droplet in DigitalOcean

- This server runs all of our services
  - API (C#)
  - Web application (Blazor)
  - Grafana, Prometheus
  - Elastic search, Kibana

### Threat sources

The database is subject to SQL injection. This could result in deleted users, twits or follows, or even the entire database. It could also result in unauthorized login, for instance by putting username to "'' AND 1 = 1; --"

The web application is subject to cross-site scripting (XSS). This could be used to gain access to our entire application.

It is also subject to broken access control, which could give access to users to data they should not have access to directly through the user interface of the application. For instance through elevation of privileges, bypassing access control checks by modifying the URL, insecure direct object references or CORS misconfiguration.

### Risk scenarios

An attacker wishes to gain access to a user's account and performs a SQL injection attack.

An attacker gains access to our DigitalOcean account by obtaining our password which we have committed to GitHub by mistake.

## Risk Analysis

We use the likelihood and impact definitions as defined by TODO: insert security book ref. The risk is found by looking at the likelihood and impact matrix as defined below:
| Risk level | | | |
|---|---|---|---|
| Likelihood | | Impact |  
| | Low | Medium | High |
| High | Low| Medium | High |
| Medium | Low | Medium | Medium |
| Low | Low | Low | Low|

| No  | Likelihood | Impact | Risk |
| --- | ---------- | ------ | ---- |
| 1   |            |        |      |
| 2   |            |        |      |
| 3   |            |        |      |

| No  | Counter measure |
| --- | --------------- |
| 1   |                 |
| 2   |                 |
| 3   |                 |
