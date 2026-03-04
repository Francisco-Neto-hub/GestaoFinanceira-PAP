/* SCRIPT DE ESTRUTURA - GESTÃO FINANCEIRA PAP
   Data: 2026-03-04
   Alinhado com o Diagrama e Core C#
*/

USE master;
GO
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BD_Finance_v1')
    CREATE DATABASE BD_Finance_v1;
GO
USE BD_Finance_v1;
GO

-- 1. Tabela de Versões (Necessária para o VersionService)
CREATE TABLE Versoes_Software (
    id_versao INT PRIMARY KEY IDENTITY(1,1),
    versao VARCHAR(20) NOT NULL,
    data_release DATETIME DEFAULT GETDATE(),
    url_download VARCHAR(255),
    notas_versao TEXT
);

-- 2. Tabela de Utilizadores
CREATE TABLE Utilizador (
    id_utilizador INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    ativo BIT DEFAULT 1 -- Campo validado no teste de integração
);

-- 3. Tabela de Contas
CREATE TABLE Conta (
    id_conta INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(50) NOT NULL,
    saldo_inicial DECIMAL(18,2) DEFAULT 0,
    id_utilizador INT FOREIGN KEY REFERENCES Utilizador(id_utilizador),
    ativo BIT DEFAULT 1
);

-- 4. Categorias
CREATE TABLE Categoria (
    id_categoria INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(50) NOT NULL,
    id_utilizador INT FOREIGN KEY REFERENCES Utilizador(id_utilizador)
);

-- 5. Tipos de Movimento (Ex: 1-Receita, 2-Despesa)
CREATE TABLE Tipo_Movimento (
    id_tipo_movimento INT PRIMARY KEY IDENTITY(1,1),
    descricao VARCHAR(20) NOT NULL
);

-- 6. Movimentos
CREATE TABLE Movimento (
    id_movimento INT PRIMARY KEY IDENTITY(1,1),
    data DATETIME DEFAULT GETDATE(),
    valor DECIMAL(18,2) NOT NULL,
    descricao VARCHAR(255),
    id_conta INT FOREIGN KEY REFERENCES Conta(id_conta),
    id_categoria INT FOREIGN KEY REFERENCES Categoria(id_categoria),
    id_tipo_movimento INT FOREIGN KEY REFERENCES Tipo_Movimento(id_tipo_movimento),
    data_criacao DATETIME DEFAULT GETDATE(),
    ativo BIT DEFAULT 1
);

-- 7. Histórico / Auditoria (Implementado no AuditService)
CREATE TABLE Historico (
    id_historico INT PRIMARY KEY IDENTITY(1,1),
    id_movimento INT FOREIGN KEY REFERENCES Movimento(id_movimento),
    data_alteracao DATETIME DEFAULT GETDATE(),
    coluna_alterada VARCHAR(50),
    valor_antigo VARCHAR(MAX),
    valor_novo VARCHAR(MAX),
    id_utilizador INT FOREIGN KEY REFERENCES Utilizador(id_utilizador)
);

-- 8. Alertas e Notificações
CREATE TABLE Alertas_Notificacoes (
    id_alerta INT PRIMARY KEY IDENTITY(1,1),
    descricao VARCHAR(255) NOT NULL
);

CREATE TABLE Utilizador_Alertas (
    id_utilizador INT FOREIGN KEY REFERENCES Utilizador(id_utilizador),
    id_conta INT FOREIGN KEY REFERENCES Conta(id_conta),
    id_alerta INT FOREIGN KEY REFERENCES Alertas_Notificacoes(id_alerta),
    data_criacao DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (id_utilizador, id_alerta)
);

-- DADOS INICIAIS PARA OS TESTES NÃO FALHAREM
INSERT INTO Tipo_Movimento (descricao) VALUES ('Receita'), ('Despesa');
INSERT INTO Versoes_Software (versao, url_download, notas_versao) 
VALUES ('1.0.0', 'https://github.com/teu-utilizador/pap', 'Lançamento inicial');