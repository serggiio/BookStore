export STATUS=1
i=0
while [[ $STATUS -ne 0 && $i -lt 60 ]]
do
    let i=i+1
    echo "**********************************"
    echo "Waiting for SQL Server to start..."
    /opt/mssql-tools/bin/sqlcmd -t 1 -S localhost -U sa -P S3cur3P@ssW0rd! -Q "SELECT 1;" > /dev/null
    STATUS=$?
    sleep 1 
done
if [ $STATUS -ne 0 ] 
then
    echo "Error: MSSQL SERVER took more than 60 seconds to start up."
    exit 1 
fi
echo "======= MSSQL SERVER STARTED ======"
path="/var/opt/mssql/data/BOOK_STORE.mdf"
if [ ! -f "$path" ]
then
    echo "***************** Restoring database: ....."
    #./db/restore_data.sh
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P S3cur3P@ssW0rd! -d master -i db/Create_Database.sql
else
    echo "********* Skipping database restore. *********"
fi
    echo "======== MSSQL CONFIG COMPLETE =========="