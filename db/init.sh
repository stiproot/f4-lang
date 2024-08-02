#!/bin/sh

/entrypoint.sh couchbase-server &

sleep 10

/opt/couchbase/init-init-cluster.sh
/opt/couchbase/init-create-bucket.sh f4lang
/opt/couchbase/init-create-scope.sh f4lang defs
/opt/couchbase/init-create-collection.sh f4lang defs agnts
/opt/couchbase/init-create-collection.sh f4lang defs pools
/opt/couchbase/indx.sh

tail -f /dev/null
