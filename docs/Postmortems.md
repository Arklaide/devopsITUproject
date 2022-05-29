## Test that your logging works
### Introduction of bug
Group A introduced a bug where they would log in as an user without using the password, since the username is unique you can still log into all the users without there password, however this maes it possible to login as every single user there is. 
### Finding the bug and fixing the bug
We can see in the log (when given a timeframe), the sql query which is triggered towards the database, it does not include any password information. This however never came around to be fixed