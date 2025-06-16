
# Explorador de Marte

Este projeto simula o controle de sondas exploratórias enviadas a Marte, que devem se movimentar em um planalto retangular, evitando colisões e limite do mesmo.

## Descrição do Problema

Cada sonda recebe comandos para se mover (`M`) e girar (`L`, `R`). As sondas:
- Operam em sequência (não em paralelo).
- Não podem ultrapassar os limites do planalto.
- Não podem ocupar a mesma posição de outra sonda.

## Como Executar o Projeto

### Pré-requisitos
- .NET 8 SDK
- Git

### Clonar e Rodar
```bash
git clone https://github.com/seuusuario/ExploradorDeMarte.git
cd ExploradorDeMarte/ExploradorDeMarte.API
dotnet run
```

A API estará disponível em: `http://localhost:5119/swagger`

---

## Como Executar os Testes

```bash
cd ExploradorDeMarte/ExploradorDeMarte.Testes
dotnet test
```

Este projeto utiliza **xUnit** como framework de testes para garantir a confiabilidade e a robustez da aplicação. Os testes cobrem as principais funcionalidades do domínio por meio de validações em **entidades**, **serviços** e **comandos**.

---

## Estrutura e Decisões de Projeto

- **Web API**: Escolhida por ser simples de executar, fácil de testar via Swagger ou postman e representar bem um sistema real.
- **Camadas separadas**:
  - `Dominio`: entidades, enums, comandos, fábricas e interfaces.
  - `API`: controllers e injeção de dependência.
  - `Testes`: cobertura unitária com xUnit.

---

## Padrões de Projeto Aplicados

- **Factory Pattern**
  - As fábricas isolam a lógica de criação dos objetos, facilitando testes e manutenção.

- **Command Pattern**
  - Cada comando (`L`, `R`, `M`) é encapsulado como um objeto que implementa a interface `IComando`.
  Isso permite adicionar novos comandos facilmente sem alterar o núcleo da lógica.

---

##  Debugging com VSCode

Para facilitar o desenvolvimento e depuração da API, foi configurado um arquivo `launch.json` em `.vscode/`,
permitindo iniciar a aplicação com `F5` diretamente no Visual Studio Code.

Durante o desenvolvimento, utilizei:
- **Breakpoints** Em métodos-chave como ExecutarComandos, Mover, GirarDireita, para acompanhar a lógica de movimentação da sonda em tempo real.
- **Inspeção de variáveis** para verificar valores como posição da sonda (X, Y) e direção (eDirecao), detectar colisões ou saídas dos limites do planalto.

---

## Pipeline de Continuous Integration

- Utilizado **GitHub Actions** com arquivo `.github/workflows/ci.yml`.
- Configuração:
  1. **Checkout do código-fonte**
    Baixa o conteúdo do repositório para o agente de execução.

  2. **Setup do ambiente .NET 8**
    Garante que o SDK .NET 8.0 esteja disponível para build e testes.

  3. **Restauração de dependências**
    Executa `dotnet restore` para baixar os pacotes NuGet.

  4. **Compilação do projeto**
    Compila em modo `Release` com `dotnet build`.

  5. **Execução dos testes**
    Roda todos os testes automatizados com `dotnet test`, gerando relatórios no formato `trx`.

  6. **Publicação de artefatos de teste (em caso de falha)**
    Se os testes falharem, os resultados são enviados como artefato para facilitar o diagnóstico via aba **Actions**.

### Resultado

Você pode visualizar os resultados e histórico de execuções diretamente na aba **[Actions](../../actions)** do GitHub.
Em caso de falha, os artefatos com os relatórios de teste estarão disponíveis para download.

---

### Exemplos de Requisições via API:

**Endpoint:** `POST api/v1/planalto`
**Payload:**
```json
{
	"LimiteX": 20,
  "LimiteY": 20
}
```
**Retorno:**
```json
{
    "mensagem": "Planalto criado com sucesso!",
    "limiteX": 20,
    "limiteY": 20
}
```

**Endpoint:** `POST api/v1/sonda`
**Payload:**
```json
{
  "nome": "sonda 3",
  "x": 1,
  "y": 2,
  "direcao": "N"
}
```
**Retorno:**
```json
{
    "mensagem": "Sonda criada com sucesso!",
    "resultado": {
        "nome": "sonda 3",
        "x": 1,
        "y": 2,
        "direcao": "N"
    }
}
```

**Endpoint:** `PUT api/v1/sonda/mover`
**Payload:**
```json
{
    "nome": "Sonda 3",
    "comandos": "R"
}
```
**Retorno:**
```json
{
    "mensagem": "Sonda movimentada com sucesso!",
    "resultado": {
        "nome": "sonda 3",
        "x": 1,
        "y": 2,
        "direcao": "E"
    }
}
```
---

##  Uso de Inteligência Artificial

O projeto contou com o apoio do ChatGPT (OpenAI).

---
