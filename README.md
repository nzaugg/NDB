NDB
===

NDB is an Object Database for .NET written in C# (forked from the NDatabase project @ http://ndatabase.codeplex.com). It functions like a Document/Object Database but is also ACID. The database is quite functional in it's current state but a lot more features are planned for this branch.

Features
========
* One single database file to store all data:
	* Meta-model
	* Objects
	* Indexes
* Handles cycle detection and circular references
* Safe access from many threads and from many processes
* Store private members (even marked as readonly)
* NoSQL, Linq support and SODA queries
* Values Queries, supporting metrics like Max, Min, Avg, Count and others
* Compatible with LinqPad
* Transactions Support (ACID)
* Store any object, no need for Serializable attribute, OID, or anything else
* Zero Configuration, just reference NDatabase3.dll
* Use as In-Memory Database
* Portability - identify types only by namespace and class name
* Automatic Database Creation
* BTree Indexes
	* Unique indexes
	* Non Unique indexes
* Paging
* Triggers
	* Select trigger (after)
	* Insert trigger (before, after)
	* Delete trigger (before, after)
	* Update trigger (before, after)
* Refactoring
	* Adding a new field (via API)
	* Removing a field (via API)
	* Rename a class (via API)
	* Rename a field (via API)
* Logging mechanism extensible with custom loggers
	* Sample loggers: log4net, Console
* NonPersistent attribute
* CascadeDelete attribute - allowing on cascade delete
* OID attribute - allows on mapping internal OID to class defined field
* Built-in caching
* Sample Northwind database
* Handle Assembly Version Changes
* Dynamic Schema Evolution
* Source Code Available
* Supported Platforms
	* Microsoft .net 3.5, 4.0, 4.5
	* Silverlight 4, Silverlight 5 (see limitations)
	* Windows Phone 7.1, Windows Phone 7.5 (see limitations)
	* Mono (4.0)
* Available on NuGet

NDB Unique Features
===================
* Collection Enumeration (see the types stored in a db)

Planned Features
================
* Better support for Identity fields
* Full Text Indexing / Searching
* Server Mode
* Replication
	* One Way
	* Merge
* Distributed Transactions
* Better support for migrations
* Sharding
* Map / Reduce Queries
* Compression & Encryption
* Scope Limiting (excluding some related objects when querying for objects)
