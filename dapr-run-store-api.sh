#!/bin/bash

# --resources-path src/dapr/components \
dapr run --app-id f4lang-store-api \
	--app-port 5079 \
	--dapr-http-port 3501 \
	-- dotnet run --project src/F4lang.Store.Api/ --urls http://localhost:5079
