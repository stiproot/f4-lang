# Examples of work item payload structure

The following is an example of how work item payloads, defined in a .yml file should be translated to a json payload.

**input .yml**
```
tasks:
  - title: Problem statement meeting
  - area_path: "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team"
  - iteration_path: "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team"
  - tags: PromoMan-Models
  - parent_id: 1173362
  - title: Identify relevant tables
  - area_path: "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team"
  - iteration_path: "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team"
  - tags: PromoMan-Models
  - parent_id: 1173362
  - title: Create temp tables for required data
  - area_path: "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team"
  - iteration_path: "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team"
  - tags: PromoMan-Models
  - parent_id: 1173362
```

**output payload**:
```
[
  {
    "type": "Task",
    "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
    "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
    "title": "Problem statement meeting",
    "description": "",
    "state": "New",
    "tags": "PromoMan-Models",
    "assigned_to": "",
    "children": [],
    "relation": {
      "relation_type": "Child",
      "url": "https://dev.azure.com/Derivco/Software/_workitems/edit/1173362"
    }
  },
  {
    "type": "Task",
    "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
    "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
    "title": "Identify relevant tables",
    "description": "",
    "state": "New",
    "tags": "PromoMan-Models",
    "assigned_to": "",
    "children": [],
    "relation": {
      "relation_type": "Child",
      "url": "https://dev.azure.com/Derivco/Software/_workitems/edit/1173362"
    }
  },
  {
    "type": "Task",
    "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
    "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
    "title": "Create temp tables for required data",
    "description": "",
    "state": "New",
    "tags": "PromoMan-Models",
    "assigned_to": "",
    "children": [],
    "relation": {
      "relation_type": "Child",
      "url": "https://dev.azure.com/Derivco/Software/_workitems/edit/1173362"
    }
  }
]
```