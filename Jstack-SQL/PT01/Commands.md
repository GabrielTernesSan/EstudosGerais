docker compose up
docker compose down
docker exec -it pg bash

cd \scripts
psql -f [1-create-table.sql || 2-alter-table.sql || 3-insert.sql]