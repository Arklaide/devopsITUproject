# Devops Group I - Metrics
## CPU load during the last hour/the last day.
1. Digital Ocean has great insights of the load on the cpu, which can be traced back to the last 14 days:
https://cloud.digitalocean.com/droplets/296029286/graphs?i=d9db54&period=hour    
2. Very interesting for the operation/devops team to see if they need to increase the size of their servers
## Average response time of your application's front page.
1. A online tool for analysing the efficiency of an webapp https://tools.pingdom.com/#601961e3c0800000
2. The results of running a google lighthouse analysis of our webapplication
![Alt text](lighthouse.PNG)
## Amount of users registered in your system. 
1. Easily seen in the database: 
Select count(*) from public."User"
2. Could be interesting for the operators and the business deparment if they want to sell it
## Average amount of followers a user has.
1. Currently we have no good way of doing this, but to query the database directly, luckely we all have acces to the prod database via a database manager:
**SELECT COUNT(*) / (SELECT COUNT(*)from public."User") from public."Follower".**
2. Interesting for the business department to see how their system is working.