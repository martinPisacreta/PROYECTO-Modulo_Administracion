create procedure buscar_ticket
(
	@AMBIENTE nvarchar (50)
)

as

select
	id,
	token,
	sign,
	expiration_time,
	generation_time,
	x_doc_request,
	x_doc_response,
	ambiente
from
	afip_ticket
where
	ambiente = @AMBIENTE