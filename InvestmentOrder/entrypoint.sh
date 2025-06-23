#!/bin/bash

# Aguarda o SQL Server iniciar

/opt/mssql/bin/sqlservr &

echo "Aguardando SQL Server iniciar..."
sleep 20s

# Executa o script SQL
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "MinhaSenha321!" -i /var/opt/mssql/scripts/init.sql

# Inicia o SQL Server no primeiro plano (mant�m o container rodando)
/opt/mssql/bin/sqlservr

wait
