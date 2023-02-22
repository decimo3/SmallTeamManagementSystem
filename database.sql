CREATE DATABASE IF NOT EXISTS aplicacao CHARACTER SET UTF8 COLLATE utf8_general_ci;
USE aplicacao;

CREATE TABLE IF NOT EXISTS viaturas (
  placa CHAR(7) NOT NULL,
  adesivo CHAR(5) NOT NULL,
  marca VARCHAR(16) NOT NULL,
  modelo VARCHAR(16) NOT NULL,
  PRIMARY KEY(placa)
);
CREATE TABLE IF NOT EXISTS funcionarios (
  modo ENUM('ativo', 'INSS', 'demitido', 'ferias') NOT NULL,
  cpf CHAR(11) NOT NULL,
  re CHAR(6) NOT NULL,
  matricula CHAR(7) NOT NULL,
  nome VARCHAR(16) NOT NULL,
  sobrenome VARCHAR(120) NOT NULL,
  apelido VARCHAR(60),
  senha CHAR(32),
  funcao ENUM('eletricista', 'supervisor', 'administrativo') DEFAULT 'eletricista',
  PRIMARY KEY(re)
);
CREATE TABLE IF NOT EXISTS equipes (
  servico ENUM('corte', 'religa', 'pqmt', 'negociacao', 'aco', 'rem') NOT NULL,
  espelho TINYINT NOT NULL,
  dia DATE NOT NULL, -- data a qual a equipe trabalhou
  supervisor CHAR(11) NOT NULL,
  motorista CHAR(11) NOT NULL,
  ajudante CHAR(11) NOT NULL,
  viatura CHAR(7) NOT NULL,
  CONSTRAINT equipe primary key(dia,servico,espelho),
  FOREIGN KEY(supervisor) REFERENCES funcionarios(re),
  FOREIGN KEY(motorista) REFERENCES funcionarios(re),
  FOREIGN KEY(ajudante) REFERENCES funcionarios(re),
  FOREIGN KEY(viatura) REFERENCES viaturas(placa)
);
CREATE TABLE IF NOT EXISTS alteracoes (
  id INT NOT NULL,
  entidade VARCHAR(16) NOT NULL,
  antes VARCHAR(500) NOT NULL, -- Armazena os dados antes da modificados
  depois VARCHAR(500) NOT NULL, -- Armazena os dados depois da modificação
  PRIMARY KEY(id)
);
