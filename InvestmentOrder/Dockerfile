
# Use a imagem oficial do SQL Server 2019 no Linux
FROM mcr.microsoft.com/mssql/server:2019-latest

# Defina variáveis de ambiente para aceitar o EULA e a senha do SA
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=MinhaSenha321!

# Crie a pasta onde os scripts ficarão dentro do container
RUN mkdir -p /scripts

# Copie o init.sql e o entrypoint.sh para dentro do container
COPY init.sql /scripts/init.sql
COPY entrypoint.sh /entrypoint.sh

# Dê permissão de execução para o entrypoint.sh
RUN chmod +x /entrypoint.sh

# Defina o script de entrada do container
ENTRYPOINT ["/entrypoint.sh"]
