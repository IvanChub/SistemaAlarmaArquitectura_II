

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Base de datos: `bdSistemaAlarma`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tb_registro`
--

CREATE TABLE `tb_registro` (
  `id` bigint(20) NOT NULL,
  `idUsuario` bigint(20) NOT NULL,
  `accionRealizada` varchar(100) COLLATE utf8_spanish2_ci NOT NULL,
  `sensor` varchar(100) COLLATE utf8_spanish2_ci NOT NULL,
  `fechaHora` varchar(200) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `tb_registro`
--


--
-- Estructura de tabla para la tabla `tb_usuario`
--

CREATE TABLE `tb_usuario` (
  `id` bigint(20) NOT NULL,
  `nombres` varchar(200) COLLATE utf8_spanish2_ci NOT NULL,
  `apellidos` varchar(100) COLLATE utf8_spanish2_ci NOT NULL,
  `usuario` varchar(50) COLLATE utf8_spanish2_ci NOT NULL,
  `passw` varchar(255) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;


--
-- Indices de la tabla `tb_registro`
--
ALTER TABLE `tb_registro`
  ADD PRIMARY KEY (`id`),
  ADD KEY `forenKey` (`idUsuario`);

--
-- Indices de la tabla `tb_usuario`
--
ALTER TABLE `tb_usuario`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `tb_registro`
--
ALTER TABLE `tb_registro`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT de la tabla `tb_usuario`
--
ALTER TABLE `tb_usuario`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `tb_registro`
--
ALTER TABLE `tb_registro`
  ADD CONSTRAINT `forenKey` FOREIGN KEY (`idUsuario`) REFERENCES `tb_usuario` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;
