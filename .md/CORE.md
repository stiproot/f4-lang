
# Core

- Actors can be stateless or stateful.
    - A stateless actor is an actor that receives an agnt qry along with the rules of how to configure the agnt
        - qry + metadata
    - A stateful actor is an actor that initializes an agnt according to some metadata (perhaps on startup), then receives qrys for this agnt

- We would like to provide an agnt manager fns at runtime that it can invoke
    - if an actor is stateful, it makes this hard, as it bootstraps fns on startup

- The Builder module is used to model agnt interactions