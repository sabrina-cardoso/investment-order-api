# InvestmentOrder.API

Este projeto é uma API de Ordens de ativos desenvolvida com foco em **arquitetura hexagonal**, integração com **Apache Kafka** e monitoramento via **Health Check customizado**.

### 🔁 O que a aplicação faz

- Expõe um endpoint HTTP que recebe ordens de ativos.
- Publica esses pedidos como mensagens em um tópico Kafka.
- Verifica a conectividade com o broker Kafka através de um health check específico.

### 🧱 Arquitetura

A aplicação segue a **arquitetura hexagonal (Ports and Adapters)**, com separação clara entre:

- Camada de entrada (API)
- Casos de uso (Application)
- Núcleo de domínio (Domain)
- Integrações externas (Infrastructure)

Essa estrutura facilita testes, manutenção e desacoplamento entre as partes da aplicação.
