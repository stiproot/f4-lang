# Work Item Formatting

Below is an example of a translation of work items, from a simple short-hand format to a correct format.

## Short Hand Format
```yml
- Sell Promotions manager to at least one iGaming customer (Not an existing customer) (Company KR) [Program]
  - 30% player uplift as measured by an increase in Deposits (BU) [Medium Project]
    - Build models to achieve 6 Business cases (Genisys + ZenAI) [Epic]
      - Present and Deliver a MDLC Process that would allow for a standardized process flow for model development by 31 May 2024 [Feature]
```

## Correct Format
```yml
- type: Programme
  title: Sell Promotions manager to at least one iGaming customer (Not an existing customer) (Company KR)
  children:
    - type: Medium Project
      title: 30% player uplift as measured by an increase in Deposits (BU)
      children:
        - type: Epic
          title: Build models to achieve 6 Business cases (Genisys + ZenAI)
          children:
            - type: Feature
              title: Present and Deliver a MDLC Process that would allow for a standardized process flow for model development by 31 May 2024
```