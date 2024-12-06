# Projeto Microsservico
Projeto para a Disciplina Arquitetura de Software

**Autores: João Daniel De Liz, João Gabriel Rosso, João Pedro Acordi**

Arquitetura de Microsserviços 
Sistema de Gestão de Compras, Vendas e Estoque com a finalidade de atender Drogarias

### Propósito do Sistema

O sistema visa otimizar e automatizar os processos operacionais de drogarias, incluindo gestão de compras, vendas e controle de estoque. Ele permite um acompanhamento preciso da disponibilidade de medicamentos, garante a conformidade com prazos de validade e possibilita um atendimento rápido e eficiente aos clientes, reduzindo perdas financeiras e melhorando a experiência do consumidor.

### Usuários do Sistema:

**Farmacêuticos e Balconistas:**

- Realizam o atendimento direto ao cliente, registram vendas e consultam disponibilidade de medicamentos.
Gerentes ou Administradores da Drogaria:

- Monitoram o estoque, acompanham vendas, aprovam pedidos de reposição e analisam relatórios operacionais.

**Equipe de Compras:**

- Gerenciam pedidos de compra, fazem negociações com fornecedores e atualizam os estoques conforme as entregas.

### Requisitos Funcionais

**Microsserviço de Compra:**

- Registrar pedidos de compra de medicamentos junto aos fornecedores.
- Atualizar o estoque automaticamente após a entrega dos medicamentos.
- Consultar a necessidade de reposição com base nos alertas de estoque mínimo.

**Microsserviço de Venda:**

- Registrar vendas de medicamentos.
- Consultar a disponibilidade de medicamentos no estoque antes de confirmar a venda.
- Aplicar descontos e promoções automaticamente, conforme regras predefinidas.
- Atualizar o estoque após a confirmação da venda.

**Microsserviço de Estoque:**
- Armazenar informações detalhadas sobre medicamentos, como quantidade, lote e validade.
- Consultar a disponibilidade de medicamentos para os microsserviços de Compra e Venda.
- Emitir alertas para medicamentos com validade próxima ou estoque insuficiente.
- Permitir a atualização de quantidades após vendas ou recebimento de compras.

### Estrutura dos Microsserviços

#### Microsserviço de Compra
*Responsabilidade:* Gerenciar a aquisição de medicamentos, incluindo pedidos a fornecedores e atualização do estoque. 

*Funções principais:*  
- Recebe os dados da compra através de um endpoint.
- Registra a compra no banco de dados local (SQLite).
- Faz uma requisição HTTP para o microsserviço de Estoque para adicionar os produtos comprados ao estoque.

#### Microsserviço de Estoque

*Responsabilidade:* Gerenciar os produtos em estoque.

*Funções principais:*  

**Possui dois endpoints:**
- Um para adicionar produtos no estoque (chamado pelo microsserviço de Compra).
- Outro para remover produtos do estoque (chamado pelo microsserviço de Venda).
- Mantém um banco de dados local para armazenar os produtos e suas quantidades.

#### Microsserviço de Venda:
*Responsabilidade:* Receber e registrar em base os pedidos relacionado as vendas e remover produtos do estoque.

*Funções principais:*  
- Recebe os dados da venda através de um endpoint.
- Registra a venda no banco de dados local (SQLite).
- Faz uma requisição HTTP para o microsserviço de Estoque para remover os produtos vendidos do estoque.

#### Fluxo de Integração e Arquitetura

*Busca no microsserviço de Estoque:*
- Venda: Ao receber um pedido, o microsserviço de Venda faz uma chamada ao microsserviço de Estoque.
- Exemplo: GET /estoque/medicamento/{id} para verificar a quantidade disponível.
- Se a quantidade for suficiente, a venda é processada.
- Se não houver estoque, o microsserviço de Venda pode exibir uma mensagem ao cliente e/ou notificar o microsserviço de Compra para reposição.
  
*Atualização no microsserviço de Estoque:*
- Compra: Após a chegada de medicamentos, o microsserviço de Compra envia uma solicitação para atualizar o estoque.
- Exemplo: PUT /estoque/medicamento/{id} para adicionar as quantidades recebidas e atualizar as validades.
- Venda: Quando uma venda é concluída, o microsserviço de Venda envia uma requisição para atualizar a quantidade disponível no estoque.
- Exemplo: PUT /estoque/medicamento/{id} para diminuir o estoque do item vendido.
  

#### Fluxo Simplificado de Operação

**Cliente realiza uma compra:**
- O microsserviço de Venda recebe o pedido de um cliente.

**Consulta ao estoque:**
- O microsserviço de Venda consulta o microsserviço de Estoque para verificar a disponibilidade do medicamento.
Validação e confirmação:
- Se o medicamento estiver disponível, o pedido é validado e confirmado.

**Atualização do estoque:**
- O microsserviço de Venda envia uma solicitação para o microsserviço de Estoque diminuir a quantidade do item vendido.
Reposição de estoque:
- Caso a quantidade mínima de um medicamento seja atingida, o microsserviço de Estoque notifica o microsserviço de Compra para iniciar o processo de reposição.

**Finalização da operação:**
- A venda é registrada e o cliente recebe a confirmação.



