#!/bin/bash

dapr run --app-id f4lang-orchestrator \
	--resources-path src/dapr/components \
	--app-port 5301 \
	--dapr-http-port 3500 \
	-- dotnet run --project src/F4lang.Orchestrator/ --urls http://localhost:5301
