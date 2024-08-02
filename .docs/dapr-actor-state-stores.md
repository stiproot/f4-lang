While actors can greatly benefit from having a state store, it is actually optional. Here's the breakdown:

Actor State Store:

An actor state store is a persistent storage mechanism used to save and retrieve the internal state of an actor. This state can include various things like user data, game progress, or any information relevant to the actor's functionality.
Benefits:
Persistence: Allows actors to maintain their state even after restarts or scaling events, making them more reliable and scalable.
Sharing: Enables actors to share state information with other actors, facilitating collaboration and complex functionalities.
Downsides:
Complexity: Adds an additional layer to your architecture, requiring setup and configuration.
Performance: Accessing external storage can introduce slight performance overhead compared to in-memory state.
When is a state store essential?

If your actor needs to maintain persistent data that survives beyond its invocation.
If your actors need to share information or collaborate with each other.
If your application requires scalability and fault tolerance.
When can you skip a state store?

If your actor only needs to hold temporary data for the duration of a single invocation.
If your actors operate independently and don't require shared state.
If your application is simple and doesn't need the benefits of persistence.
Remember:

Choosing to use an actor state store depends on your specific application requirements.
Even without a state store, actors can still function, but their capabilities and resilience might be limited.
Dapr supports various state store options like Redis, Cosmos DB, and Azure Table Storage, offering flexibility based on your needs.
Additional Resources:

Dapr State Management Overview: https://docs.dapr.io/developing-applications/building-blocks/state-management/state-management-overview/
Actors Overview: https://docs.dapr.io/developing-applications/building-blocks/actors/actors-overview/