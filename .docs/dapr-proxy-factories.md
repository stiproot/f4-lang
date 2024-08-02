
# Static Actor Proxy Factory vs DI:

If you don't need actor reentrancy:

Use the static ActorProxyFactory to create an actor proxy. This method works regardless of where the actor call originates within your application.

If you need actor reentrancy:

Use the dependency injection provided by the Dapr SDK. By registering the IActorProxyFactory interface in your actor's constructor, you can inject a factory instance specific to the current actor context. This allows for reentrancy because the runtime understands the call chain and unlocks the actor for subsequent requests within the same chain.

Important notes:

- While the static method is simpler, using dependency injection is generally recommended due to its potential for reentrancy, especially in complex actor interactions.

- Remember that actors are single-threaded, so using reentrancy requires careful design to avoid deadlocks.

- Refer to the Dapr documentation for more details on actor reentrancy and using the actor proxy factory:
