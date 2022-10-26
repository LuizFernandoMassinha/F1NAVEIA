-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 25-Out-2022 às 04:03
-- Versão do servidor: 10.4.24-MariaDB
-- versão do PHP: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `amantesf1`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `opiniao`
--

CREATE TABLE `opiniao` (
  `nomeUsuario` varchar(25) DEFAULT NULL,
  `mensagemdoUsuario` varchar(450) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `opiniao`
--

INSERT INTO `opiniao` (`nomeUsuario`, `mensagemdoUsuario`) VALUES
('Luiz Fernando ', 'Lewis Hamilton é o maior da história!\r\nTanto dentro quanto fora das pistas!!\r\n'),
('Vanessa Lima', 'O Pierre Gasly metece uma equipe melhor para correr, seu potêncial é bem maior que o da Alpha Tauri!\r\n'),
('Lucas', 'Acho que o Ricardo podia dar lugar ao Drugovich na McLaren!'),
('Lucas', 'Hamilton é PT');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `IdUsuario` int(11) NOT NULL,
  `nomeUsuario` varchar(30) NOT NULL,
  `emailUsuario` varchar(15) NOT NULL,
  `foneUsuario` varchar(30) NOT NULL,
  `loginUsuario` varchar(15) NOT NULL,
  `senhaUsuario` varchar(8) NOT NULL,
  `datadenascimentoUsuario` date NOT NULL,
  `sexodoUsuario` varchar(10) NOT NULL,
  `mensagemdoUsuario` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`IdUsuario`, `nomeUsuario`, `emailUsuario`, `foneUsuario`, `loginUsuario`, `senhaUsuario`, `datadenascimentoUsuario`, `sexodoUsuario`, `mensagemdoUsuario`) VALUES
(2, 'Lucas Lima', 'lucas@gmail.com', '11 99986-5630', 'lucas', '03092017', '2017-09-03', '\0', '1ª criança do grupo'),
(3, 'Marina Lima', 'marinalima@gmai', '11 98255-4915', 'marinoca', '18072013', '2013-07-18', '\0', 'Primeira garota do grupo'),
(4, 'Luiz Fernando ', 'luletotti@gmail', '11 98255-4915', 'totti', '260386', '1986-03-26', '\0', 'Quero entrar nesse grupo '),
(5, 'Vanessa Lima', 'vanessa@gmail.c', '11 98256-5431', 'Vanessa', '160486', '1986-04-16', '\0', 'Testando Vanessa'),
(6, 'Paulo Marcos', 'paulomd9@gmail.', '11 98563-5462', 'Paulinho', '090388', '1988-03-09', '\0', 'Novo teste');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
