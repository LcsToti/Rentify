# Documentação Rentify

O **Rentify** é um sistema de gestão de aluguel que facilita a administração de imóveis para inquilinos, proprietários e imobiliárias. Ele permite gerenciar contratos, pagamentos, manutenção e comunicação de forma eficiente e transparente.

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do sistema.

### Requisitos Funcionais

| ID   | Descrição                                                   | Estabilidade | Prioridade | Status     |
| ---- | ----------------------------------------------------------- | ------------ | ---------- | ---------- |
| RF01 | Cadastro de usuários (inquilino, proprietário, imobiliária) | Estável      | Alta       | Aprovado   |
| RF02 | Cadastro de imóveis                                         | Estável      | Alta       | Aprovado   |
| RF03 | Edição de imóveis                                           | Estável      | Alta       | Aprovado   |
| RF04 | Exclusão de imóveis                                         | Estável      | Alta       | Aprovado   |
| RF05 | Histórico de negociações                                    | Instável     | Média      | Em Análise |
| RF06 | Chat entre clientes e imobiliárias                          | Estável      | Média      | Aprovado   |
| RF07 | Solicitação e acompanhamento de tickets de atendimento      | Instável     | Média      | Aprovado   |
| RF08 | Relatórios Financeiros para ambas às partes                 | Volátil      | Baixa      | Em Análise |
| RF09 | Notificações e lembretes automáticos                        | Instável     | Média      | Rascunho   |

---

### Requisitos Não Funcionais

| ID    | Descrição                                                                                                           |
| ----- | ------------------------------------------------------------------------------------------------------------------- |
| RNF01 | Suportar múltiplos usuários simultâneos sem redução de performance, com até 100 usuários simultâneos                |
| RNF02 | Tempo de resposta para ações críticas (login, cadastro) deve ser menor que 2 segundos                               |
| RNF03 | Senhas dos usuários devem ser armazenadas de forma segura através do Hash com BCrypt                                |
| RNF04 | Implementar controle de acesso baseado em papéis (RBAC) para Usuário, Proprietário, Imobiliária                     |
| RNF05 | Interface deve ser responsiva para diferentes dispositivos.                                                         |
| RNF06 | Tempo de uptime confiável de 99%.                                                                                   |
| RNF07 | A arquitetura deve permitir fácil adição de novas funcionalidades seguindo boas práticas, sendo modular e escalável |

_\*Os valores são aproximados e podem ser ajustados conforme necessário._
