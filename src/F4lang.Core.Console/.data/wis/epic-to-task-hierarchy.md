# Here is an example of work item translation

## Example Input

There are two key pieces of information required to create the output. 
The first is the work item hierarchy in YAML format and the second is the additional work item details provided as TEXT.

1. Work item hierarchy in YAML format.
```yml
- epic:
  - title: Causal AI Simulations on All Models
  - description: Our Causal AI should be able to simulate player behavior and determine the best incentive based on scoring for all our production models.
    - features:
      - feature:
        - title: Player Experience Simulations & Missing Data
        - description: 
        - user_stories:
          - user_story:
            - title: Data acquisition
            - tasks:
              - task:
                - title: Registration data
```

2. Additional work item details in JSON format
```text
parent id: 1173362,
tags: "Reboot",
area path: "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
iteration path: "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
```

## Example Output
```json
[
  {
    "type": "Epic",
    "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
    "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
    "title": "Casual AI Simulations on All Models",
    "description": "Our Causal AI should be able to simulate player behavior and determine the best incentive based on scoring for all our production models.",
    "acceptance_criteria": "",
    "state": "New",
    "tags": "Reboot",
    "story_points": "",
    "assigned_to": "",
    "relation": {
      "relation_type": "Child",
      "url": "https://dev.azure.com/Derivco/Software/_workitems/edit/1173362"
    },
    "children": [
      {
        "type": "Feature",
        "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
        "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
        "title": "Player Experience Simulations & Missing Data",
        "description": "",
        "acceptance_criteria": "",
        "state": "New",
        "tags": "Reboot",
        "story_points": "",
        "assigned_to": "",
        "children": [
          {
            "type": "User Story",
            "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
            "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
            "title": "Data acquisition",
            "description": "",
            "acceptance_criteria": "",
            "state": "New",
            "tags": "Reboot",
            "story_points": "",
            "assigned_to": "",
            "children": [
              {
                "type": "Task",
                "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
                "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
                "title": "Registration data",
                "description": "",
                "state": "New",
                "tags": "",
                "assigned_to": "Simon Stipich",
                "remaining": "",
                "original_estimate": ""
              }
            ]
          }
        ]
      }
    ]
  }
]
```