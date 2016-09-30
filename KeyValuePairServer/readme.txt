Scope completed:
- library to provide a memory data structure to store key/value paris as instructed
- sample server implementation to handle the commands
- unit tests for both

Projects:
- KeyValueProvider - library implementation
- KeyValueProviderTests - unit tests
- KeyValueClient - sample console application to present protocol commands on the server

Key classes:
KeyValuePairProvider
- offers storage of key value paris with LRU removal strategy
- initialized up to n elements of the capacity
- uses dictionary for fast lookups and elements storage
- uses dictionary and linked list for LRU tracking

KeyValuePairProviderFactory
- initializes an instance of the KeyValuePairProvider and returns abstracted interface IKeyValuePairProvider

KeyValuePairServer
- sample server implementation that handled string commands and calls underlying implementation if IKeyValuePairProvider

Unit tests:
- test the KeyValuePairProvider for proper handling of the Get/Put commands and LRU removal strategy
- project presends the dependency injection technique and mocking of the provider on the tests for KeyValuePairServer

Areas not covered (scope vs time limit):
- network connection (this could be achieved by a simple TcpListener to expose a port and listen for commands
- thread safety (the implementation requires concurrency access control) to the collection, should be added at the KeyValuePairProvider level
- better handling of the application protocol (should be refactored to a separate class and return some kind of object that is a command and used by the KeyValuePairServer)
- better parameter values control (check for nulls on keys/values, check for the capacity parameter)
- better exception handling (on operations, if they failed for instance due to out of memory exceptions)

