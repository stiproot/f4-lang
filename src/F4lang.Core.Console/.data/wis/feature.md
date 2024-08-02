# Examples of work item payload structure

**input text**
feature: Cloud Technology Upskilling
  - story: Dapr POC
    - task: Choose component to use Dapr
    - task: Demo POC

parent id: 1173362
assinged to: Simon Stipcich
tags: Reboot
area path: "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
iteration path: "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",

**output payload**:
```
[
  {
    "type": "Feature",
    "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
    "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
    "title": "Cloud Technology Upskilling",
    "description": "",
    "acceptance_criteria": "",
    "state": "New",
    "tags": "Reboot",
    "assigned_to": "Simon Stipich",
    "relation": {
      "relation_type": "Child",
      "url": "https://dev.azure.com/Derivco/Software/_workitems/edit/1173362"
    },
    "children": [
    {
        "type": "User Story",
        "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
        "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
        "title": "Dapr POC",
        "description": "",
        "acceptance_criteria": "",
        "state": "New",
        "tags": "Reboot",
        "story_points": "",
        "assigned_to": "Simon Stipich",
        "children": [
          {
            "type": "Task",
            "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
            "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
            "title": "Choose component to use Dapr",
            "description": "",
            "state": "New",
            "tags": "Reboot",
            "assigned_to": "Simon Stipich",
            "remaining": "",
            "original_estimate": ""
          },
          {
            "type": "Task",
            "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
            "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
            "title": "Demo POC",
            "description": "",
            "state": "New",
            "tags": "Reboot",
            "assigned_to": "Simon Stipich",
            "remaining": "",
            "original_estimate": ""
          }
        ]
      }
    ]
  }
]
```