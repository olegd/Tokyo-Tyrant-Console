Tokyo Tyrant Console 
=====================

Tokyo Tyrant Console is a comand line tool which allows interacts with Tokyo Tyrant

Setup
-----

Put Tokyo Tyrant server address and port into Tokyo-Tyrant-Console.exe.config: 

    <add key="TTHost" value="127.0.0.1"/>
    <add key="TTPort" value="1978"/>

Supported Commands
------

    Tokyo-Tyrant-Console --findby-key keyName

>*Returns all columns for a key that matches exactly with the keyName supplied.*

    Tokyo-Tyrant-Console --findby-columns columnName1:columnValue1 [columnName2:columnValue2]

>*Returns all keys and columns that have columns with values that match columnValue1 AND columnValue2*



    Tokyo-Tyrant-Console --update-key keyName columnName1:columnValue1 [columnName2:columnValue2]

>*Updates column valus for a given key. If column does not exist it is created. If column already has data, it is overwritten.*


    Tokyo-Tyrant-Console --delete-key keyName

>*Deletes a key and all columns assosiated with it.*

