import chromadb

client = chromadb.HttpClient(host="localhost", port=8000)

collections = client.list_collections()

collection = client.get_collection("")
collection_count = collection.count()
print(collection.id)
print(collection.name)
print(collection_count)

query_results = collection.query(query_texts=[""], n_results=1)
print(query_results)

# new_collection = client.create_collection("new-collection")
# new_collection.add(
#    documents=[
#        "Atoms are the building blocks of matter",
#        "Atoms are the Lego blocks of matter",
#    ],
#    metadatas=[{"author": "Simon Stipcich"}, {"source": "Memoirs of a Madman"}],
#    ids=["1", "2"],
# )
