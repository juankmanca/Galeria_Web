-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 24-04-2019 a las 02:16:04
-- Versión del servidor: 5.7.11
-- Versión de PHP: 5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `galeria`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `album`
--

CREATE TABLE `album` (
  `AlbumID` int(11) NOT NULL,
  `NombreAlbum` varchar(50) NOT NULL,
  `Descripcion` varchar(50) NOT NULL,
  `UsuarioID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `albumordenado`
--

CREATE TABLE `albumordenado` (
  `NumeroOrden` int(11) NOT NULL,
  `AlbumID` int(11) NOT NULL,
  `ImagenID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `imagen`
--

CREATE TABLE `imagen` (
  `ImagenID` int(11) NOT NULL,
  `Foto` varchar(50) NOT NULL,
  `Titulo` varchar(50) NOT NULL,
  `Descripcion` varchar(50) NOT NULL,
  `Comentario` varchar(50) NOT NULL,
  `UsuarioID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `PersonaID` int(11) NOT NULL,
  `Cedula` bigint(20) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `correo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `persona`
--

INSERT INTO `persona` (`PersonaID`, `Cedula`, `Nombre`, `correo`) VALUES
(1, 2345, 'juankmilo', ''),
(2, 1234, 'camilo', 'juankmanca@gmail.com'),
(3, 123456789, 'ricardo', 'ricar@gmail.com'),
(4, 432, 'ocampo', 'juank');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `UsuarioID` int(11) NOT NULL,
  `NombreUsuario` varchar(50) NOT NULL,
  `contrasena` varchar(50) NOT NULL,
  `Avatar` varchar(50) NOT NULL,
  `PersonaID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`UsuarioID`, `NombreUsuario`, `contrasena`, `Avatar`, `PersonaID`) VALUES
(2, '123', 'juankmanca', '3', 2),
(3, '345', 'asdf', '2', 3),
(4, 'juank', '123', '1', 4);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `album`
--
ALTER TABLE `album`
  ADD PRIMARY KEY (`AlbumID`),
  ADD KEY `UsuarioID` (`UsuarioID`);

--
-- Indices de la tabla `albumordenado`
--
ALTER TABLE `albumordenado`
  ADD PRIMARY KEY (`AlbumID`,`ImagenID`) USING BTREE,
  ADD KEY `ImagenID` (`ImagenID`);

--
-- Indices de la tabla `imagen`
--
ALTER TABLE `imagen`
  ADD PRIMARY KEY (`ImagenID`),
  ADD KEY `UsuarioID` (`UsuarioID`);

--
-- Indices de la tabla `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`PersonaID`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`UsuarioID`),
  ADD KEY `PersonaID` (`PersonaID`),
  ADD KEY `PersonaID_2` (`PersonaID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `album`
--
ALTER TABLE `album`
  MODIFY `AlbumID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `imagen`
--
ALTER TABLE `imagen`
  MODIFY `ImagenID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `PersonaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `UsuarioID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `album`
--
ALTER TABLE `album`
  ADD CONSTRAINT `album_ibfk_1` FOREIGN KEY (`UsuarioID`) REFERENCES `usuario` (`UsuarioID`);

--
-- Filtros para la tabla `albumordenado`
--
ALTER TABLE `albumordenado`
  ADD CONSTRAINT `albumordenado_ibfk_3` FOREIGN KEY (`AlbumID`) REFERENCES `album` (`AlbumID`),
  ADD CONSTRAINT `albumordenado_ibfk_4` FOREIGN KEY (`ImagenID`) REFERENCES `imagen` (`ImagenID`);

--
-- Filtros para la tabla `imagen`
--
ALTER TABLE `imagen`
  ADD CONSTRAINT `imagen_ibfk_1` FOREIGN KEY (`UsuarioID`) REFERENCES `usuario` (`UsuarioID`);

--
-- Filtros para la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`PersonaID`) REFERENCES `persona` (`PersonaID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
