create procedure insert_ticket
(
	@TOKEN	nvarchar(MAX),
	@SIGN	nvarchar(MAX),
	@EXPIRATION_TIME	datetime,
	@GENERATION_TIME	datetime,
	@XDOC_REQUEST	nvarchar(MAX),
	@XDOC_RESPONSE	nvarchar(MAX),
	@AMBIENTE	nvarchar (50)

)

as


insert into afip_ticket
values
(
	@TOKEN,
	@SIGN,
	@EXPIRATION_TIME,
	@GENERATION_TIME,
	@XDOC_REQUEST,
	@XDOC_RESPONSE,
	@AMBIENTE
)
