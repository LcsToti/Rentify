# Rentify Documentation

## Requisitos

As tabelas a seguir detalham os requisitos funcionais e não funcionais do sistema.

# **Requisitos Funcionais (v1.0)**

| **ID** | **Descrição**                                             | **Estabilidade** | **Prioridade** | **Status** |
| ------ | --------------------------------------------------------- | ---------------- | -------------- | ---------- |
| RF01   | Cadastro e Login de imobiliárias                          | Estável          | Alta           | Aprovado   |
| RF02   | Inclusão de processos de aluguel                          | Estável          | Alta           | Aprovado   |
| RF03   | Inclusão de eventos para os processos de aluguel          | Estável          | Alta           | Aprovado   |
| RF04   | Edição de eventos para os processos de aluguel            | Estável          | Alta           | Aprovado   |
| RF05   | Remoção de eventos para os processos de aluguel           | Estável          | Alta           | Aprovado   |
| RF06   | Exibição de histórico de eventos dos processos de aluguel | Estável          | Alta           | Aprovado   |
| RF07   | Lembretes Automáticos                                     | Estável          | Média          | Aprovado   |
| RF08   | Protocolos de Problemas (Tickets) com Status              | Estável          | Alta           | Aprovado   |
| RF09   | Retorno sobre o status financeiro                         | Estável          | Média          | Aprovado   |

### **Requisitos Não Funcionais (v1.0)**

| ID    | Descrição                                                                                                           |
| ----- | ------------------------------------------------------------------------------------------------------------------- |
| RNF01 | Suportar múltiplos usuários simultâneos sem degradação de desempenho, até 100 usuários concorrentes                 |
| RNF02 | O tempo de resposta para ações críticas (login, cadastro) deve ser inferior a 2 segundos                            |
| RNF03 | As senhas dos usuários devem ser armazenadas com segurança usando **Hash com BCrypt**                               |
| RNF04 | Implementar **controle de acesso baseado em funções (RBAC)** para administração de imobiliárias                     |
| RNF05 | A interface deve ser responsiva para diferentes dispositivos                                                        |
| RNF06 | Garantir um tempo de atividade confiável de **99%**                                                                 |
| RNF07 | A arquitetura deve permitir fácil adição de novas funcionalidades seguindo boas práticas, sendo modular e escalável |

_\*Os valores são aproximados e podem ser ajustados conforme necessário._

## **Stack**

As seguintes tecnologias serão utilizadas no sistema Rentify:

### **Backend**

- **ASP.NET Web API**: Para construir a API, oferecendo uma arquitetura robusta e escalável.
- **Entity Framework Core**: ORM para interação com o banco de dados MySQL.
- **JWT / OAuth2**: Mecanismos de autenticação e autorização para acesso seguro dos usuários.

### **Frontend**

- **React.js**: Biblioteca principal para a interface do usuário.
- **Next.js**: Framework para melhorar SEO, SSR e facilitar a estruturação do projeto.

### **Banco de Dados**

- **MySQL**: Banco de dados relacional para armazenar e gerenciar informações de contratos e histórico.

### **Controle de Versão**

- **Git**: Sistema de controle de versão para rastrear mudanças e facilitar a colaboração.
