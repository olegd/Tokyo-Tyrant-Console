Tokyo Tyrant Console 
=====================

Tokyo Tyrant Console is a way to interact with Tokyo Tyrant from command line

Setup
-----

Put TT server address and port into Tokyo-Tyrant-Console.exe.config: 

* TTHost 
* TTPort

Read
------

Tokyo-Tyrant-Console --findby-key keyName

Returns all columns for a given key.

Update
-------
Tokyo-Tyrant-Console --update-key keyName columnName1:columnValue1 [columnName2:columnValue2]

Updates column valus for a given key. If column does not exist it is created. If column already has data, it is overwritten.

Delete
-------
Tokyo-Tyrant-Console --delete-key keyName

Deletes a key and all columns assosiated with it.

