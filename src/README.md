# 🧠 ORIENTA - Plataforma de Apoio para Professores e Alunos com IA

Plataforma educacional desenvolvida com foco em potencializar a criação e aplicação de **questionários inteligentes**. A proposta é oferecer uma **ferramenta dinâmica e acessível** para professores criarem conteúdos avaliativos, e para alunos responderem de forma simples, com sugestões da IA baseadas no perfil de aprendizado.

---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/)
- C# com ASP.NET Core Web API
- Entity Framework Core
- SQL Server (ou outro banco relacional)
- Design Patterns:
  - **Domain-Driven Design (DDD)**
  - **Abstract Factory** (para criação de questionários)
- Injeção de dependência com `Microsoft.Extensions.DependencyInjection`
- RESTful APIs
- Swagger (em breve)

---

## 📦 Organização do Projeto

| Camada             | Finalidade                                            |
| ------------------ | ----------------------------------------------------- |
| **Domain**         | Entidades, contratos, enums e regras puras de negócio |
| **Application**    | Casos de uso, DTOs e providers de fábrica             |
| **Infrastructure** | Implementações de persistência e fábricas concretas   |
| **API**            | Endpoints de acesso e configuração da aplicação       |

---

## 🏗️ Padrão Abstract Factory Aplicado

Neste projeto, utilizamos o padrão **Abstract Factory** para desacoplar a criação de `QuestionarioEntity` conforme o tipo:

- `QuestionarioProfessorFactory`: Criação por professores
- `QuestionarioIAFactory`: Criação automática com sugestões da IA

Essas fábricas são injetadas dinamicamente via o `QuestionarioFactoryProvider`, garantindo flexibilidade e escalabilidade na criação dos questionários.

---

## 🔧 Como Rodar Localmente

### 1. Clone o repositório

```bash
git clone https://github.com/BrunKsp/backend-orienta.git
cd backend-orienta
```

### 2. Configure o banco de dados

Altere a .env

### 3. Execute o projeto

```bash
cd src/Orienta.API
dotnet run
```

## A API estará disponível por padrão em:

- 📍 http://localhost:5254

## 📚 Funcionalidades

- Criação de questionários via Abstract Factory

- Inserção e validação de perguntas com alternativas

- Separação clara de responsabilidades por camada

- Sugestão de questões via IA (em progresso)

- Painel administrativo (futuro)

- Autenticação com JWT (futuro)


## 🤝 Contribuições
Sinta-se livre para enviar PRs, sugestões ou relatar problemas.
Esse projeto é parte de uma evolução acadêmica e profissional com foco em arquitetura e boas práticas de desenvolvimento.