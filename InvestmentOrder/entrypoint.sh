#!/bin/bash

# Aguarda o SQL Server iniciar
echo "Aguardando SQL Server iniciar..."
sleep 20s

# Executa o script SQL
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "MinhaSenha321!" -i /scripts/init.sql

# Inicia o SQL Server no primeiro plano (mantém o container rodando)
/opt/mssql/bin/sqlservr
