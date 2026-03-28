# Sistema de Gerenciamento Acadêmico (AED II)

Projeto desenvolvido para a disciplina de Algoritmos e Estruturas de Dados II, com foco em manipulação de dados em memória e persistência em arquivos.  

Na versão atual do projeto, somente **vetores** puderam ser utilizados como forma de armazenamento em memória. Todavia, o projeto provavelmente será
utilizado para aprendizado de outras estruturas de dados, como Listas Encadeadas, Pilhas, Filas e Grafos.

## Objetivo

Simular um sistema acadêmico capaz de gerenciar:

- Alunos
- Disciplinas
- Matrículas

Sem uso de banco de dados, utilizando **arquivos `.dat` e estruturas de dados**.

---

## Conceitos Aplicados

- Estruturas de Dados (vetores)
- Manipulação de arquivos (leitura e escrita)
- Organização em camadas:
  - Entidades (Models)
  - Repositórios (Data)
  - Serviços
- Controle manual de IDs (matrícula)
- Complexidade de algoritmos (buscas e inserções)

---

## Estrutura do Projeto

- Entities/ # Classes de domínio (Aluno, Disciplina, Matrícula)
-  Data/ # Manipulação de arquivos e armazenamento
- Repositorios/ # Gerenciamento de dados e entidades
- Services/ # Regras de negócio
- Program.cs # Ponto de entrada

## Desafios Técnicos
- Gerenciamento manual de IDs (sem banco)
- Manter consistência após deleções
- Otimização de busca sem uso de estruturas avançadas
- Sincronização entre memória e arquivo

## Tecnologias

- C#
- .NET
- Programação Orientada a Objetos (POO)
