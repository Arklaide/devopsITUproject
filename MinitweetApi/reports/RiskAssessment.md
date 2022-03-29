# Risk Assessment

## Risk Identification

- Identifiy assets (e.g. web application)
- Identify threat sources (e.g. SQL injection)
- Construct risk scenarios (e.g. Attacker performs SQL injection on web application to download sensitive user data)

### Assets

Database

- user info

- twits

Server/droplet in DigitalOcean

- This server runs all of our services
  - API
  - Web application
  - Grafana, Prometheus

### Threat sources

The database is subject to SQL injection. This could result in deleted users, twits or follows, or even the entire database. It could also result in unauthorized login, for instance by putting username to "'' AND 1 = 1; --"

The web application is subject to cross-site scripting (XSS). This could be used to gain access to our entire application.

It is also subject to broken access control, which could give access to users to data they should not have access to directly through the user interface of the application. For instance through elevation of privileges, bypassing access control checks by modifying the URL, insecure direct object references or CORS misconfiguration.

### Risk scenarios

An attacker wishes to gain access to a user's account and performs a SQL injection attack.

An attacker gains access to our DigitalOcean account by obtaining our password which we have committed to GitHub by mistake.

## Risk Analysis
