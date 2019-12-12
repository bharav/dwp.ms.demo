#wait for the SQL Server to come up

sleep 60s

echo "running set up script"

#run the setup script to create the DB and the schema in the DB

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pass@word -d master -i vehicle-init.sql