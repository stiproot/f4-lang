# Examples of work item payload structure

The following is an example of how work item payloads, defined in a .yml file should be translated to a json payload.

**input .yml**
```
epic: MLDLC Template
  - area_path: "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team"
  - iteration_path: "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team"
  - tags: PromoMan-Models

  - feature: Problem statement
    - area_path: "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team"
    - iteration_path: "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team"
    - description: | 
        A high level description of the problem that does not impact the design of the solution yet.
        Technical and business users meet to discuss the problem and agree on the problem statement having some idea of possible interventions or levers to pull to solve the problem based on outputs from the model.
    
    - story: Problem statement kick-off
      - description: |
          A meeting with technical and business owners to discuss the problem statement and have alignment from inception. 
          Involve all required personel to ensure a clear understanding of the problem and the impact of the problem.
      - acceptance_criteria: |
          Kick-off meeting with relevant stakeholders,
          agreed-upon problem statement, 
          sign off to continue to next steps
          If the problem statement is not agreed upon, and more/other stakeholders need to be included, the process starts again.
      - points: 2
      - tags: PromoMan-Models
```

**output payload**:
```
[
  {
    "type": "Epic",
    "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
    "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
    "title": "MLDLC Template",
    "description": "",
    "state": "New",
    "tags": "PromoMan-Models",
    "assigned_to": "",
    "remaining": "",
    "original_estimate": ""
    "children": [
      {
          "type": "Feature",
          "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
          "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
          "title": "Problem statement",
          "description": "A high level description of the problem that does not impact the design of the solution yet. Technical and business users meet to discuss the problem and agree on the problem statement having some idea of possible interventions or levers to pull to solve the problem based on outputs from the model.", 
          "acceptance_criteria": "",
          "state": "New",
          "tags": "PromoMan-Models",
          "assigned_to": "",
          "children": [
          {
              "type": "User Story",
              "area_path": "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team",
              "iteration_path": "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team",
              "title": "Problem statement kick-off",
              "description": "",
              "acceptance_criteria": "Kick-off meeting with relevant stakeholders, agreed-upon problem statement, sign off to continue to next steps If the problem statement is not agreed upon, and more/other stakeholders need to be included, the process starts again.",
              "state": "New",
              "tags": "PromoMan-Models",
              "story_points": "2",
              "assigned_to": "",
              "children": []
            }
          ]
        }
    ]
  }
]
```