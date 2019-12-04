-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 29-11-2019 a las 02:08:04
-- Versión del servidor: 10.1.38-MariaDB
-- Versión de PHP: 7.2.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dtsamp`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE `users` (
  `id` int(250) NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` varchar(256) NOT NULL,
  `salt` varchar(256) NOT NULL,
  `email` varchar(250) DEFAULT NULL,
  `age` int(3) NOT NULL DEFAULT '0',
  `genre` int(1) NOT NULL,
  `skin` int(3) NOT NULL,
  `x` double NOT NULL DEFAULT '0',
  `y` double NOT NULL DEFAULT '0',
  `z` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `salt`, `email`, `age`, `genre`, `skin`, `x`, `y`, `z`) VALUES
(8, 'Muphy_Pingotee', '$2b$10$wOp9qyr08vJmxYYCKem6.es2CsTbdAbiWUy4cjAprkDSf9l.NPuW.', '$2b$10$wOp9qyr08vJmxYYCKem6.e', 'fsadfsd@das.com', 0, 0, 0, 132, -67.62654876708984, 1.578125),
(14, 'Albert_Rosher', '$2b$10$rxz.K9F28vL6UlVP2PQT.OmXEpnEIgaxZFEsI3oMCC74.t/rFYWHa', '$2b$10$rxz.K9F28vL6UlVP2PQT.O', 'sadas@sdad.com', 22, 1, 147, 298.4534912109375, -67.19730377197266, 1.3336769342422485);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `vehicles`
--

CREATE TABLE `vehicles` (
  `id` int(250) NOT NULL,
  `owner` int(250) NOT NULL,
  `model` int(3) NOT NULL,
  `color1` int(3) NOT NULL,
  `color2` int(3) NOT NULL,
  `numberplate` varchar(8) NOT NULL,
  `x` double NOT NULL,
  `y` double NOT NULL,
  `z` double NOT NULL,
  `rot` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `vehicles`
--

INSERT INTO `vehicles` (`id`, `owner`, `model`, `color1`, `color2`, `numberplate`, `x`, `y`, `z`, `rot`) VALUES
(1, 14, 402, 1, 1, 'JEJEJEJE', 298.4534912109375, -67.19730377197266, 1.3336769342422485, 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `vehicles`
--
ALTER TABLE `vehicles`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `users`
--
ALTER TABLE `users`
  MODIFY `id` int(250) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `vehicles`
--
ALTER TABLE `vehicles`
  MODIFY `id` int(250) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
