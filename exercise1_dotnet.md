# 2 Hour Coding Exercise
 
# Key-Value Server
 
The task is to construct a key-value server (think: like a very basic single node version of memcached or redis)
 
* The server should maintain a mapping, in memory, of keys to values
* Keys and values are ASCII strings
* The server should allow a maximum of N key-values to be in memory at any one time, as further entries are added, the oldest entries should be evicted first. N should be configurable
 
## Operations
 
* PUT - The server should support putting a value against a key
* GET - The server should support looking up and returning the value (if any) for a key
 
## Client interaction
 
Clients should interact with the server by opening a TCP connection and using a very simple text based protocol
 
In the following <key> is the key to put, <value> is the value. Both key and value are ASCII strings and cannot contain a new-line character.
 
\n is a new line character
 
The protocol is as follows:
 
### PUT
 
To put a key-value pair:
 
PUT\n
<key>\n
<value>\n
 
should return
 
OK\n - when put succeeds
 
FAIL\n if the put fails
 
<value> cannot be an empty string
 
### GET
 
To get a value given a key
 
GET\n
<key>\n
 
Should return:
 
<value>\n
 
<value> should be an empty string if there is no entry for that key
 
## Important notes
 
* Please use *only* standard .NET framework classes, no other third party dependencies/Nuget packages. The only exception is the testing tool as mentioned below.
* Please provide client side tests - you can use any popular test tool (e.g. NUnit, Specflow) for this
* Feel free to browse the web. Please do not copy code from the web or books though!
* Please push your completed project to GitHub
* Please provide a simple README for the project
* Bonus points - provide a simple client API to access the server
* Don't worry if you can't get it all complete in the time, but it's better to submit something that partially works than nothing at all.
 
Good luck!

