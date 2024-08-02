#!/bin/bash

# dapr invoke --app-id f4lang-store-api \
#     --method agnt \
#     --data '{"agntId":"promise-tree-dev"}' \
#     --verb POST

dapr invoke --app-id f4lang-store-api \
    --method agnt/promise-tree-dev \
    --verb POST