# Rentify Documentation

## Requirements

The following tables outline the functional and non-functional requirements detailing the system's scope.

### Functional Requirements

| ID   | Description                                           | Stability | Priority | Status       |
| ---- | ----------------------------------------------------- | --------- | -------- | ------------ |
| RF01 | User registration (tenant, owner, real estate agency) | Stable    | High     | Approved     |
| RF02 | Property registration                                 | Stable    | High     | Approved     |
| RF03 | Property editing                                      | Stable    | High     | Approved     |
| RF04 | Property deletion                                     | Stable    | High     | Approved     |
| RF05 | Negotiation history                                   | Unstable  | Medium   | Under Review |
| RF06 | Chat between clients and real estate agencies         | Stable    | Medium   | Approved     |
| RF07 | Ticket request and tracking for support               | Unstable  | Medium   | Approved     |
| RF08 | Financial reports for both parties                    | Volatile  | Low      | Under Review |
| RF09 | Automatic notifications and reminders                 | Unstable  | Medium   | Draft        |

### Non-Functional Requirements

| ID    | Description                                                                                                      |
| ----- | ---------------------------------------------------------------------------------------------------------------- |
| RNF01 | Support multiple simultaneous users without performance degradation, up to 100 concurrent users                  |
| RNF02 | Response time for critical actions (login, registration) must be under 2 seconds                                 |
| RNF03 | User passwords must be securely stored using Hash with BCrypt                                                    |
| RNF04 | Implement role-based access control (RBAC) for User, Owner, Real Estate Agency                                   |
| RNF05 | The interface must be responsive across different devices                                                        |
| RNF06 | Reliable uptime of 99%                                                                                           |
| RNF07 | The architecture should allow easy addition of new features following best practices, being modular and scalable |

_\*Values are approximate and may be adjusted as needed._

## Tech Stack
