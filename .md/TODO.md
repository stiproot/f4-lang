
- actors calling actors
    - fns wrap actor proxy factory?
    - should the actor invocation happen at the agnt manager level?

- event driven communication
    - does this mean each agnt/actor needs a input topic & an output topic?

# Qs
- Should all fns be actors?
    - In order for a fn to be invoked, an event would need to be published to q, where an actor would be listening.
    - Seems like overkill for certain fns, like IO...
A: Abstract agnt communication, so that it can achieve both.

- Should the cache live at the agnt manager level?
    - What is being cached?
    A: agnt chat history + final res
    - Can the agnt cache be swapped out for an agnts state store?

- What strategies for resolving a qry should be supported?
A: 
    - agnt sequential flow: agnts are invoked in some sequential order
    - agnt pool: agnts can invoke other agnts in a pool
    - single agnt: single call to an agnt
