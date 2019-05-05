
CREATE TABLE cat_estatus
( 
	IdTipoEstatus        integer  NOT NULL ,
	IdEstatus            integer  NOT NULL ,
	DesEstatus           varchar(50)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE cat_estatus
	ADD  PRIMARY KEY  CLUSTERED (IdEstatus ASC)
go



CREATE TABLE cat_generales
( 
	IdTipoGeneral        integer  NULL ,
	IdGeneral            integer  NOT NULL ,
	DesGeneral           varchar(50)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE cat_generales
	ADD  PRIMARY KEY  CLUSTERED (IdGeneral ASC)
go



CREATE TABLE cat_parametros
( 
	IdParametro          integer  NOT NULL ,
	DesParametro         varchar(20)  NULL ,
	Valor                integer  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE cat_parametros
	ADD  PRIMARY KEY  CLUSTERED (IdParametro ASC)
go



CREATE TABLE cat_periodos
( 
	IdPeriodo            smallint  NOT NULL ,
	PeriodoIni           datetime  NULL ,
	PeriodoFin           datetime  NULL ,
	DesPeriodo           varchar(100)  NULL ,
	Año                  smallint  NULL ,
	NombreCorto          varchar(30)  NULL ,
	NumPeriodo           char(1)  NULL ,
	TipoPeriodo          varchar(50)  NULL ,
	FechaReg             datetime  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	ClavePeriodo         varchar(5)  NULL ,
	NumDias              smallint  NULL 
)
go



ALTER TABLE cat_periodos
	ADD  PRIMARY KEY  CLUSTERED (IdPeriodo ASC)
go



CREATE TABLE cat_periodos_actividades
( 
	IdActividad          smallint  NOT NULL ,
	FechaReg             datetime  NULL ,
	FechaIni             datetime  NULL ,
	FechaFin             datetime  NULL ,
	TipoDia              vachar(50)  NULL ,
	Justificacion        varchar(1000)  NULL ,
	Mensaje              varchar(3000)  NULL ,
	SeLabora             char(1)  NULL ,
	VerAPartirDe         datetime  NULL ,
	VerHasta             datetime  NULL ,
	DesActividad         varchar(200)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	SeSuspendeClases     char(1)  NULL ,
	IdPeriodo            smallint  NOT NULL 
)
go



ALTER TABLE cat_periodos_actividades
	ADD  PRIMARY KEY  CLUSTERED (IdPeriodo ASC,IdActividad ASC)
go



CREATE TABLE cat_periodos_actividades_archivos
( 
	IdRutaArchivo        integer  NOT NULL ,
	RutaArchivo          varchar(1000)  NULL ,
	Principal            char(1)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdActividad          smallint  NOT NULL ,
	IdPeriodo            smallint  NOT NULL ,
	IdTipoArchivo        integer  NULL 
)
go



ALTER TABLE cat_periodos_actividades_archivos
	ADD  PRIMARY KEY  CLUSTERED (IdPeriodo ASC,IdActividad ASC,IdRutaArchivo ASC)
go



CREATE TABLE cat_periodos_suspension_labores
( 
	HoraIni              time  NULL ,
	HoraFin              time  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdSuspension         varchar(20)  NOT NULL ,
	IdActividad          smallint  NOT NULL ,
	IdPeriodo            smallint  NOT NULL 
)
go



ALTER TABLE cat_periodos_suspension_labores
	ADD  PRIMARY KEY  CLUSTERED (IdPeriodo ASC,IdActividad ASC,IdSuspension ASC)
go



CREATE TABLE cat_tipo_estatus
( 
	IdTipoEstatus        integer  NOT NULL ,
	DesTipoEstatus       varchar(50)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE cat_tipo_estatus
	ADD  PRIMARY KEY  CLUSTERED (IdTipoEstatus ASC)
go



CREATE TABLE cat_tipos_generales
( 
	IdTipoGeneral        integer  NOT NULL ,
	DesTipoGeneral       varchar(50)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE cat_tipos_generales
	ADD  PRIMARY KEY  CLUSTERED (IdTipoGeneral ASC)
go



CREATE TABLE ce_cajas_gestion
( 
	IdCaja               integer  NULL ,
	IdGestionCaja        integer  NOT NULL ,
	Activo               varchar(20)  NULL ,
	Borrado              varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdEstatus            integer  NULL 
)
go



ALTER TABLE ce_cajas_gestion
	ADD  PRIMARY KEY  CLUSTERED (IdGestionCaja ASC)
go



CREATE TABLE ce_cajas_movimientos
( 
	IdMovtoCaja          integer  NULL ,
	Activo               varchar(20)  NULL ,
	Borrado              varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdTipoMovtoCaja      integer  NULL ,
	IdMovto              integer  NOT NULL ,
	MontoAut             float  NULL ,
	Observacion          varchar(255)  NULL ,
	MontoReal            float  NULL ,
	IdGestionCaja        integer  NULL 
)
go



ALTER TABLE ce_cajas_movimientos
	ADD  PRIMARY KEY  CLUSTERED (IdMovto ASC)
go



CREATE TABLE ce_cat_almacenes
( 
	IdAlmacen            varchar(20)  NOT NULL ,
	DesAlmacen           varchar(20)  NULL ,
	Capacidad            varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_cat_almacenes
	ADD  PRIMARY KEY  NONCLUSTERED (IdAlmacen ASC)
go



CREATE TABLE ce_cat_cajas
( 
	IdCaja               integer  NOT NULL ,
	DesCaja              varchar(50)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdTipoCaja           integer  NULL 
)
go



ALTER TABLE ce_cat_cajas
	ADD  PRIMARY KEY  CLUSTERED (IdCaja ASC)
go



CREATE TABLE ce_cat_conceptos_prod_serv
( 
	IdProdServ           integer  NOT NULL ,
	CodigoBarras         varchar(20)  NULL ,
	ClaveProdServ        varchar(20)  NULL ,
	DesProdServ          varchar(20)  NULL ,
	IdTipoProdServ       integer  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_cat_conceptos_prod_serv
	ADD  PRIMARY KEY  CLUSTERED (IdProdServ ASC)
go



CREATE TABLE ce_cat_inventarios
( 
	Ubicacion            varchar(50)  NULL ,
	CantidadDisponible   float  NULL ,
	StockMinimo          float  NULL ,
	StockMaximo          float  NULL ,
	IdAlmacen            varchar(20)  NOT NULL ,
	IdProdServ           integer  NOT NULL ,
	IdPresentacion       varchar(20)  NOT NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	CantidadApartada     float  NULL ,
	CantidadMerma        float  NULL 
)
go



ALTER TABLE ce_cat_inventarios
	ADD  PRIMARY KEY  CLUSTERED (IdProdServ ASC,IdAlmacen ASC,IdPresentacion ASC)
go



CREATE TABLE ce_cat_listas
( 
	IdLista              integer  NOT NULL ,
	DesLista             varchar(50)  NULL ,
	TipoLista            varchar(50)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_cat_listas
	ADD  PRIMARY KEY  NONCLUSTERED (IdLista ASC)
go



CREATE TABLE ce_cat_listas_precios_prod_serv
( 
	Precio               float  NULL ,
	IdLista              integer  NOT NULL ,
	IdPresentacion       varchar(20)  NOT NULL ,
	IdProdServ           integer  NOT NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IVA                  float  NULL 
)
go



ALTER TABLE ce_cat_listas_precios_prod_serv
	ADD  PRIMARY KEY  CLUSTERED (IdLista ASC,IdProdServ ASC,IdPresentacion ASC)
go



CREATE TABLE ce_cat_prod_serv
( 
	IdProdServ           integer  NOT NULL ,
	Marca                varchar(50)  NULL ,
	Modelo               varchar(50)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	PuntosXVenta         integer  NULL ,
	IdTipoCondicion      integer  NULL ,
	IdEstatus            integer  NULL ,
	IdTipoGrupo          integer  NULL ,
	IdTipoDepto          integer  NULL 
)
go



ALTER TABLE ce_cat_prod_serv
	ADD  PRIMARY KEY  CLUSTERED (IdProdServ ASC)
go



CREATE TABLE ce_cat_prod_serv_cajeables
( 
	IdTipoCajeable       integer  NOT NULL ,
	Valor                integer  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdProdServ           integer  NOT NULL 
)
go



ALTER TABLE ce_cat_prod_serv_cajeables
	ADD  PRIMARY KEY  CLUSTERED (IdProdServ ASC,IdTipoCajeable ASC)
go



CREATE TABLE ce_cat_prod_serv_caracteristicas
( 
	IdCaracteristica     varchar(20)  NOT NULL ,
	Valor                varchar(255)  NULL ,
	DesCaracteristica    varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	IdProdServ           integer  NOT NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_cat_prod_serv_caracteristicas
	ADD  PRIMARY KEY  CLUSTERED (IdCaracteristica ASC,IdProdServ ASC)
go



CREATE TABLE ce_cat_prod_serv_presenta
( 
	IdPresentacion       varchar(20)  NOT NULL ,
	Color1               varchar(20)  NULL ,
	IdProdServ           integer  NOT NULL ,
	Color2               varchar(20)  NULL ,
	IdUnidadMedida       varchar(20)  NULL ,
	Valor                float  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_cat_prod_serv_presenta
	ADD  PRIMARY KEY  CLUSTERED (IdProdServ ASC,IdPresentacion ASC)
go



CREATE TABLE ce_cat_prod_serv_presenta_archivos
( 
	IdProdServ           integer  NOT NULL ,
	IdPresentacion       varchar(20)  NOT NULL ,
	IdRutaArchivo        integer  NOT NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdTipoArchivo        integer  NULL ,
	RutaArchivo          varchar(255)  NULL ,
	Principal            char(1)  NULL 
)
go



ALTER TABLE ce_cat_prod_serv_presenta_archivos
	ADD  PRIMARY KEY  CLUSTERED (IdPresentacion ASC,IdRutaArchivo ASC,IdProdServ ASC)
go



CREATE TABLE ce_cat_promo_prod_serv
( 
	IdProdServ           integer  NOT NULL ,
	IdPresentacion       varchar(20)  NOT NULL ,
	IdPromocion          varchar(20)  NOT NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_cat_promo_prod_serv
	ADD  PRIMARY KEY  CLUSTERED (IdProdServ ASC,IdPromocion ASC,IdPresentacion ASC)
go



CREATE TABLE ce_cat_promociones
( 
	IdPromocion          varchar(20)  NOT NULL ,
	DesPromocion         varchar(20)  NULL ,
	FechaExpiraIni       datetime  NULL ,
	FechaExpiraFin       datetime  NULL ,
	Valor                varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdTipoPromocion      integer  NULL ,
	IdTipoDescuento      integer  NULL 
)
go



ALTER TABLE ce_cat_promociones
	ADD  PRIMARY KEY  NONCLUSTERED (IdPromocion ASC)
go



CREATE TABLE ce_cat_promociones_aplica_a
( 
	IdPromocion          varchar(20)  NOT NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Valor                varchar(50)  NOT NULL ,
	IdTipoAplicaA        integer  NULL 
)
go



ALTER TABLE ce_cat_promociones_aplica_a
	ADD  PRIMARY KEY  CLUSTERED (IdPromocion ASC,Valor ASC)
go



CREATE TABLE ce_cat_promociones_cantidad_fisica
( 
	IdPromocion          varchar(20)  NOT NULL ,
	Valor                integer  NULL ,
	ValorAcumulado       integer  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdTipoDescuento      integer  NULL 
)
go



ALTER TABLE ce_cat_promociones_cantidad_fisica
	ADD  PRIMARY KEY  CLUSTERED (IdPromocion ASC)
go



CREATE TABLE ce_cat_tipos_canjeables
( 
	IdTipoCajeable       integer  NOT NULL ,
	DesTipoCanjeable     varchar(20)  NULL ,
	ValorPuntos          integer  NULL ,
	ValorMonedaLocal     integer  NULL 
)
go



ALTER TABLE ce_cat_tipos_canjeables
	ADD  PRIMARY KEY  CLUSTERED (IdTipoCajeable ASC)
go



CREATE TABLE ce_cat_unidad_medidas
( 
	IdUnidadMedida       varchar(20)  NOT NULL ,
	DesUnidadMedida      varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_cat_unidad_medidas
	ADD  PRIMARY KEY  NONCLUSTERED (IdUnidadMedida ASC)
go



CREATE TABLE ce_creditos
( 
	IdCredito            integer  NOT NULL ,
	PlazoEnMeses         integer  NULL ,
	InteresCredito       float  NULL ,
	Enganche             float  NULL ,
	MontoTotal           integer  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdTipoPeriodoPago    integer  NULL ,
	IdPedido             integer  NULL ,
	InteresMoratorio     float  NULL ,
	IdTipoPeriodoMora    integer  NULL ,
	IdAval               integer  NULL ,
	IdAcreedor           integer  NULL ,
	NumDiasPago          integer  NULL ,
	MesNatural           char(1)  NULL 
)
go



ALTER TABLE ce_creditos
	ADD  PRIMARY KEY  CLUSTERED (IdCredito ASC)
go



CREATE TABLE ce_creditos_beneficioarios
( 
	IdCredito            integer  NOT NULL ,
	IdCreditoBene        integer  NOT NULL ,
	Porcentaje           integer  NULL ,
	Activo               varchar(20)  NULL ,
	Borrado              varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdBeneficiario       integer  NULL 
)
go



ALTER TABLE ce_creditos_beneficioarios
	ADD  PRIMARY KEY  CLUSTERED (IdCredito ASC,IdCreditoBene ASC)
go



CREATE TABLE ce_creditos_det
( 
	IdCredito            integer  NOT NULL ,
	IdCreditoDet         integer  NOT NULL ,
	NumPago              integer  NULL ,
	SaldoCapitalAnterior float  NULL ,
	PagoCapital          float  NULL ,
	PagoInteres          float  NULL ,
	MontoPago            float  NULL ,
	SaldoCapitalActual   float  NULL ,
	FechaPago            datetime  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_creditos_det
	ADD  PRIMARY KEY  CLUSTERED (IdCredito ASC,IdCreditoDet ASC)
go



CREATE TABLE ce_facturas
( 
	IdFactura            integer  NOT NULL ,
	IdVenta              integer  NULL ,
	FolioFactura         varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdEmisor             integer  NULL ,
	IdReceptor           integer  NULL ,
	IdDomicilioEmisor    integer  NULL ,
	IdDomicilioReceptor  integer  NULL ,
	SubTotal             float  NULL ,
	IVA                  float  NULL ,
	Total                float  NULL 
)
go



ALTER TABLE ce_facturas
	ADD  PRIMARY KEY  CLUSTERED (IdFactura ASC)
go



CREATE TABLE ce_inventario_series_caracteristicas
( 
	NumSerie             varchar(20)  NOT NULL ,
	IdCaracterisitca     integer  NOT NULL ,
	DesCaracteristica    varchar(50)  NULL ,
	Valor                varchar(255)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_inventario_series_caracteristicas
	ADD  PRIMARY KEY  CLUSTERED (NumSerie ASC,IdCaracterisitca ASC)
go



CREATE TABLE ce_inventarios_series
( 
	NumSerie             varchar(20)  NOT NULL ,
	Activo               varchar(20)  NULL ,
	Borrado              varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Referencia           varchar(50)  NULL ,
	IdTipoCondicion      integer  NULL ,
	IdAlmacen            varchar(20)  NULL ,
	IdProdServ           integer  NULL ,
	IdPresentacion       varchar(20)  NULL ,
	UbicacionDet         varchar(50)  NULL 
)
go



ALTER TABLE ce_inventarios_series
	ADD  PRIMARY KEY  CLUSTERED (NumSerie ASC)
go



CREATE TABLE ce_invetarios_series_estatus
( 
	NumSerie             varchar(20)  NOT NULL ,
	IdEstatusDet         integer  NOT NULL ,
	FechaReg             datetime  NULL ,
	Actual               char(1)  NULL ,
	Observacion          varchar(255)  NULL ,
	ReferenciaPedVta     varchar(50)  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdEstatus            integer  NULL ,
	TipoPedidoVenta      char(1)  NULL 
)
go



ALTER TABLE ce_invetarios_series_estatus
	ADD  PRIMARY KEY  CLUSTERED (NumSerie ASC,IdEstatusDet ASC)
go



CREATE TABLE ce_lista_favoritos
( 
	IdListaFavorito      integer  NOT NULL ,
	DesListaFavorito     varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	Activo               varchar(20)  NULL ,
	Borrado              varchar(20)  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_lista_favoritos
	ADD  PRIMARY KEY  CLUSTERED (IdListaFavorito ASC)
go



CREATE TABLE ce_listas_favoritos_prod_serv
( 
	IdListaFavorito      integer  NULL ,
	IdListaFavoritoDet   varchar(20)  NOT NULL ,
	FechaReg             datetime  NULL ,
	IdProdServ           integer  NULL ,
	IdPresentacion       varchar(20)  NULL ,
	Precio               float  NULL ,
	NotificarBajaPrecio  char(1)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE ce_listas_favoritos_prod_serv
	ADD  PRIMARY KEY  CLUSTERED (IdListaFavoritoDet ASC)
go



CREATE TABLE ce_listas_montos_conceptos
( 
	IdLista              integer  NOT NULL ,
	IdProdServ           integer  NOT NULL ,
	IdProdServReferencia integer  NULL ,
	Valor                float  NULL ,
	IVA                  float  NULL ,
	IdTipoValor          integer  NULL ,
	IdTipoConcepto       integer  NULL ,
	SumaResta            char(1)  NULL ,
	IdTipoAplicaA        integer  NULL ,
	IdPresentaReferencia varchar(20)  NULL 
)
go



ALTER TABLE ce_listas_montos_conceptos
	ADD  PRIMARY KEY  CLUSTERED (IdLista ASC,IdProdServ ASC)
go



CREATE TABLE ce_pedidos
( 
	IdPedido             integer  NOT NULL ,
	IdPersona            integer  NULL ,
	IdTipoPedido         integer  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	SubTotal             float  NULL ,
	IVA                  float  NULL ,
	Total                float  NULL ,
	FechaExpiraIni       datetime  NULL ,
	FechaExpiraFin       datetime  NULL 
)
go



ALTER TABLE ce_pedidos
	ADD  PRIMARY KEY  CLUSTERED (IdPedido ASC)
go



CREATE TABLE ce_pedidos_prod_serv
( 
	IdPedido             integer  NOT NULL ,
	IdPedidoDet          integer  NOT NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	PrecioUnitario       float  NULL ,
	Cantidad             float  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	MontoIVA             float  NULL ,
	IVA                  float  NULL ,
	SubTotal             float  NULL ,
	Monto                float  NULL ,
	IdProdServ           integer  NULL ,
	IdPresentacion       varchar(20)  NULL 
)
go



ALTER TABLE ce_pedidos_prod_serv
	ADD  PRIMARY KEY  CLUSTERED (IdPedido ASC,IdPedidoDet ASC)
go



CREATE TABLE ce_venta_forma_pago
( 
	IdVenta              integer  NOT NULL ,
	Nombre               varchar(50)  NULL ,
	Domicilio            varchar(50)  NULL ,
	Telefono             varchar(20)  NULL ,
	NumDoctoOficial      varchar(20)  NULL ,
	Sexo                 char(1)  NULL ,
	MontoValor           float  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdTipoFormaPago      integer  NULL ,
	NumDocumento         varchar(20)  NULL ,
	IdTipoDoctoOficial   integer  NULL ,
	RutaDocumento        varchar(255)  NULL 
)
go



ALTER TABLE ce_venta_forma_pago
	ADD  PRIMARY KEY  CLUSTERED (IdVenta ASC)
go



CREATE TABLE ce_ventas
( 
	IdVenta              integer  NOT NULL ,
	IdTipoVenta          integer  NULL ,
	SubTotal             integer  NULL ,
	IVA                  float  NULL ,
	Total                float  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdPedido             integer  NULL ,
	IdCliente            integer  NULL ,
	IdCajero             integer  NULL ,
	IdMovto              integer  NULL ,
	FolioVenta           integer  NULL ,
	IdTipoFormaPago      integer  NULL 
)
go



ALTER TABLE ce_ventas
	ADD  PRIMARY KEY  CLUSTERED (IdVenta ASC)
go



CREATE TABLE ce_ventas_prod_serv
( 
	IdVentaDet           integer  NOT NULL ,
	IdVenta              integer  NOT NULL ,
	Cantidad             float  NULL ,
	PrecioUnitario       float  NULL ,
	IVA                  float  NULL ,
	Monto                float  NULL ,
	MontoIVA             float  NULL ,
	SubTotal             float  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdProdServ           integer  NULL ,
	IdPresentacion       varchar(20)  NULL 
)
go



ALTER TABLE ce_ventas_prod_serv
	ADD  PRIMARY KEY  CLUSTERED (IdVenta ASC,IdVentaDet ASC)
go



CREATE TABLE rh_cat_dir_webs
( 
	IdDirWeb             integer  NOT NULL ,
	DesDirWeb            varchar(50)  NULL ,
	DireccionWeb         varchar(255)  NULL ,
	Principal            char(1)  NULL ,
	IdTipoDirWeb         integer  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltAct          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdPersona            integer  NULL ,
	IdTipoTelefono       integer  NULL 
)
go



ALTER TABLE rh_cat_dir_webs
	ADD  PRIMARY KEY  CLUSTERED (IdDirWeb ASC)
go



CREATE TABLE rh_cat_domicilios
( 
	IdDomicilio          integer  NOT NULL ,
	Domicilio            varchar(50)  NULL ,
	EntreCalle1          varchar(50)  NULL ,
	EntreCalle2          varchar(50)  NULL ,
	CodigoPostal         varchar(10)  NULL ,
	Coordenadas          varchar(255)  NULL ,
	Principal            char(1)  NULL ,
	Pais                 varchar(50)  NULL ,
	Estado               varchar(50)  NULL ,
	Municipio            varchar(50)  NULL ,
	Localidad            varchar(50)  NULL ,
	Colonia              varchar(50)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdTipoDomicilio      integer  NULL ,
	IdPersona            integer  NULL ,
	RFC                  varchar(20)  NULL 
)
go



ALTER TABLE rh_cat_domicilios
	ADD  PRIMARY KEY  CLUSTERED (IdDomicilio ASC)
go



CREATE TABLE rh_cat_personas
( 
	IdPersona            integer  NOT NULL ,
	Nombre               varchar(20)  NULL ,
	ApPaterno            varchar(20)  NULL ,
	ApMaterno            varchar(20)  NULL ,
	PuntosAcumulados     integer  NULL ,
	Alias                varchar(20)  NULL ,
	Sexo                 char(1)  NULL ,
	RFC                  varchar(20)  NULL ,
	FechaNac             datetime  NULL ,
	RutaFoto             varchar(255)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL 
)
go



ALTER TABLE rh_cat_personas
	ADD  PRIMARY KEY  CLUSTERED (IdPersona ASC)
go



CREATE TABLE rh_cat_telefonos
( 
	IdTelefono           integer  NOT NULL ,
	IdPersona            integer  NULL ,
	CodPais              varchar(5)  NULL ,
	NumTelefono          varchar(20)  NULL ,
	NumExtension         varchar(10)  NULL ,
	Principal            char(1)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	IdTipoTelefono       integer  NULL 
)
go



ALTER TABLE rh_cat_telefonos
	ADD  PRIMARY KEY  CLUSTERED (IdTelefono ASC)
go




ALTER TABLE cat_estatus
	ADD  FOREIGN KEY (IdTipoEstatus) REFERENCES cat_tipo_estatus(IdTipoEstatus)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE cat_generales
	ADD  FOREIGN KEY (IdTipoGeneral) REFERENCES cat_tipos_generales(IdTipoGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE cat_periodos_actividades
	ADD  FOREIGN KEY (IdPeriodo) REFERENCES cat_periodos(IdPeriodo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE cat_periodos_actividades_archivos
	ADD  FOREIGN KEY (IdPeriodo,IdActividad) REFERENCES cat_periodos_actividades(IdPeriodo,IdActividad)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE cat_periodos_actividades_archivos
	ADD  FOREIGN KEY (IdTipoArchivo) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE cat_periodos_suspension_labores
	ADD  FOREIGN KEY (IdPeriodo,IdActividad) REFERENCES cat_periodos_actividades(IdPeriodo,IdActividad)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cajas_gestion
	ADD  FOREIGN KEY (IdCaja) REFERENCES ce_cat_cajas(IdCaja)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cajas_gestion
	ADD  FOREIGN KEY (IdEstatus) REFERENCES cat_estatus(IdEstatus)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cajas_movimientos
	ADD  FOREIGN KEY (IdTipoMovtoCaja) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cajas_movimientos
	ADD  FOREIGN KEY (IdGestionCaja) REFERENCES ce_cajas_gestion(IdGestionCaja)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_cajas
	ADD  FOREIGN KEY (IdTipoCaja) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_conceptos_prod_serv
	ADD  FOREIGN KEY (IdTipoProdServ) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_inventarios
	ADD  FOREIGN KEY (IdAlmacen) REFERENCES ce_cat_almacenes(IdAlmacen)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_inventarios
	ADD  FOREIGN KEY (IdProdServ,IdPresentacion) REFERENCES ce_cat_prod_serv_presenta(IdProdServ,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_listas_precios_prod_serv
	ADD  FOREIGN KEY (IdLista) REFERENCES ce_cat_listas(IdLista)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_listas_precios_prod_serv
	ADD  FOREIGN KEY (IdProdServ,IdPresentacion) REFERENCES ce_cat_prod_serv_presenta(IdProdServ,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv
	ADD  FOREIGN KEY (IdTipoCondicion) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv
	ADD  FOREIGN KEY (IdEstatus) REFERENCES cat_estatus(IdEstatus)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv
	ADD  FOREIGN KEY (IdTipoGrupo) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv
	ADD  FOREIGN KEY (IdTipoDepto) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv
	ADD  FOREIGN KEY (IdProdServ) REFERENCES ce_cat_conceptos_prod_serv(IdProdServ)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv_cajeables
	ADD  FOREIGN KEY (IdProdServ) REFERENCES ce_cat_prod_serv(IdProdServ)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv_cajeables
	ADD  FOREIGN KEY (IdTipoCajeable) REFERENCES ce_cat_tipos_canjeables(IdTipoCajeable)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv_caracteristicas
	ADD  FOREIGN KEY (IdProdServ) REFERENCES ce_cat_prod_serv(IdProdServ)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv_presenta
	ADD  FOREIGN KEY (IdProdServ) REFERENCES ce_cat_prod_serv(IdProdServ)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv_presenta
	ADD  FOREIGN KEY (IdUnidadMedida) REFERENCES ce_cat_unidad_medidas(IdUnidadMedida)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv_presenta_archivos
	ADD  FOREIGN KEY (IdProdServ,IdPresentacion) REFERENCES ce_cat_prod_serv_presenta(IdProdServ,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_prod_serv_presenta_archivos
	ADD  FOREIGN KEY (IdTipoArchivo) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_promo_prod_serv
	ADD  FOREIGN KEY (IdProdServ,IdPresentacion) REFERENCES ce_cat_prod_serv_presenta(IdProdServ,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_promo_prod_serv
	ADD  FOREIGN KEY (IdPromocion) REFERENCES ce_cat_promociones(IdPromocion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_promociones
	ADD  FOREIGN KEY (IdTipoPromocion) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_promociones
	ADD  FOREIGN KEY (IdTipoDescuento) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_promociones_aplica_a
	ADD  FOREIGN KEY (IdPromocion) REFERENCES ce_cat_promociones(IdPromocion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_promociones_aplica_a
	ADD  FOREIGN KEY (IdTipoAplicaA) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_promociones_cantidad_fisica
	ADD  FOREIGN KEY (IdPromocion) REFERENCES ce_cat_promociones(IdPromocion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_cat_promociones_cantidad_fisica
	ADD  FOREIGN KEY (IdTipoDescuento) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_creditos
	ADD  FOREIGN KEY (IdTipoPeriodoPago) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_creditos
	ADD  FOREIGN KEY (IdPedido) REFERENCES ce_pedidos(IdPedido)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_creditos
	ADD  FOREIGN KEY (IdTipoPeriodoMora) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_creditos
	ADD  FOREIGN KEY (IdAval) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_creditos
	ADD  FOREIGN KEY (IdAcreedor) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_creditos_beneficioarios
	ADD  FOREIGN KEY (IdCredito) REFERENCES ce_creditos(IdCredito)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_creditos_beneficioarios
	ADD  FOREIGN KEY (IdBeneficiario) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_creditos_det
	ADD  FOREIGN KEY (IdCredito) REFERENCES ce_creditos(IdCredito)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_facturas
	ADD  FOREIGN KEY (IdVenta) REFERENCES ce_ventas(IdVenta)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_facturas
	ADD  FOREIGN KEY (IdEmisor) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_facturas
	ADD  FOREIGN KEY (IdReceptor) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_facturas
	ADD  FOREIGN KEY (IdDomicilioEmisor) REFERENCES rh_cat_domicilios(IdDomicilio)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_facturas
	ADD  FOREIGN KEY (IdDomicilioReceptor) REFERENCES rh_cat_domicilios(IdDomicilio)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_inventario_series_caracteristicas
	ADD  FOREIGN KEY (NumSerie) REFERENCES ce_inventarios_series(NumSerie)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_inventarios_series
	ADD  FOREIGN KEY (IdTipoCondicion) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_inventarios_series
	ADD  FOREIGN KEY (IdProdServ,IdAlmacen,IdPresentacion) REFERENCES ce_cat_inventarios(IdProdServ,IdAlmacen,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_invetarios_series_estatus
	ADD  FOREIGN KEY (NumSerie) REFERENCES ce_inventarios_series(NumSerie)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_invetarios_series_estatus
	ADD  FOREIGN KEY (IdEstatus) REFERENCES cat_estatus(IdEstatus)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_listas_favoritos_prod_serv
	ADD  FOREIGN KEY (IdListaFavorito) REFERENCES ce_lista_favoritos(IdListaFavorito)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_listas_favoritos_prod_serv
	ADD  FOREIGN KEY (IdProdServ,IdPresentacion) REFERENCES ce_cat_prod_serv_presenta(IdProdServ,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_listas_montos_conceptos
	ADD  FOREIGN KEY (IdLista) REFERENCES ce_cat_listas(IdLista)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_listas_montos_conceptos
	ADD  FOREIGN KEY (IdProdServ) REFERENCES ce_cat_conceptos_prod_serv(IdProdServ)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_listas_montos_conceptos
	ADD  FOREIGN KEY (IdTipoValor) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_listas_montos_conceptos
	ADD  FOREIGN KEY (IdTipoConcepto) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_listas_montos_conceptos
	ADD  FOREIGN KEY (IdTipoAplicaA) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_listas_montos_conceptos
	ADD  FOREIGN KEY (IdProdServReferencia,IdPresentaReferencia) REFERENCES ce_cat_prod_serv_presenta(IdProdServ,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_pedidos
	ADD  FOREIGN KEY (IdPersona) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_pedidos
	ADD  FOREIGN KEY (IdTipoPedido) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_pedidos_prod_serv
	ADD  FOREIGN KEY (IdPedido) REFERENCES ce_pedidos(IdPedido)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_pedidos_prod_serv
	ADD  FOREIGN KEY (IdProdServ,IdPresentacion) REFERENCES ce_cat_prod_serv_presenta(IdProdServ,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_venta_forma_pago
	ADD  FOREIGN KEY (IdVenta) REFERENCES ce_ventas(IdVenta)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_venta_forma_pago
	ADD  FOREIGN KEY (IdTipoFormaPago) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_venta_forma_pago
	ADD  FOREIGN KEY (IdTipoDoctoOficial) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_ventas
	ADD  FOREIGN KEY (IdTipoVenta) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_ventas
	ADD  FOREIGN KEY (IdPedido) REFERENCES ce_pedidos(IdPedido)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_ventas
	ADD  FOREIGN KEY (IdCliente) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_ventas
	ADD  FOREIGN KEY (IdCajero) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_ventas
	ADD  FOREIGN KEY (IdMovto) REFERENCES ce_cajas_movimientos(IdMovto)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_ventas
	ADD  FOREIGN KEY (IdTipoFormaPago) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_ventas_prod_serv
	ADD  FOREIGN KEY (IdVenta) REFERENCES ce_ventas(IdVenta)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ce_ventas_prod_serv
	ADD  FOREIGN KEY (IdProdServ,IdPresentacion) REFERENCES ce_cat_prod_serv_presenta(IdProdServ,IdPresentacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE rh_cat_dir_webs
	ADD  FOREIGN KEY (IdPersona) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE rh_cat_dir_webs
	ADD  FOREIGN KEY (IdTipoTelefono) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE rh_cat_domicilios
	ADD  FOREIGN KEY (IdTipoDomicilio) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE rh_cat_domicilios
	ADD  FOREIGN KEY (IdPersona) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE rh_cat_telefonos
	ADD  FOREIGN KEY (IdPersona) REFERENCES rh_cat_personas(IdPersona)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE rh_cat_telefonos
	ADD  FOREIGN KEY (IdTipoTelefono) REFERENCES cat_generales(IdGeneral)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go