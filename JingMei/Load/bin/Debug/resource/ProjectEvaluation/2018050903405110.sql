USE [UFDATA_999_2018]
GO

/****** Object:  StoredProcedure [dbo].[zz_tiaoma_p_10]    Script Date: 2018/4/25 19:02:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--生成产成品入库单
CREATE procedure [dbo].[zz_tiaoma_p_10]
@tmid varchar(50),
@position varchar(50),
@cacc_id varchar(20),
@ccode varchar(30) output
as

set xact_abort on
begin Transaction

declare @warehouse varchar(50)
declare @iquantity float
declare @cinvcode varchar(100)
declare @sfhwgl int  --是否货位管理
declare @free1 varchar(20)

--根据货位找仓库
exec zz_get_warehouse_by_position @position,@warehouse output
--判断仓库是否货位管理
select @sfhwgl=isnull(bWhPos,0) from Warehouse where cWhCode=@warehouse


select @iquantity=qty,@cinvcode=cinvCode,@free1=free1
from UF_ext_QRCODE
where isnull(statu,0)=0 and id=@tmid

if @iquantity>0
begin
	--获得单据号
	declare @djh varchar(100)
	exec Proc_GetSeqence  '产成品入库单号','',''
	select @djh=code from RUL_Sequence where SeqCode='产成品入库单号'

	--构建表头临时表开始 ************************************************

	--获得最大id 、默认仓库、日期、单据号、采购类型
	update zz_example_rdrecord10
	set ID=NULL,
	CWHCODE=NULL,
	DDATE=NULL,
	CCODE=NULL,
	CDEPCODE=NULL,
	CMAKER=NULL,
	cHandler=NULL,
	CMPOCODE=NULL,
	IPROORDERID=NULL,
	DNMAKETIME=GETDATE(),
	dnverifytime=NULL,
	CSYSBARCODE=NULL,
	cCheckSignFlag=NULL,
	dVeriDate=NULL

	UPDATE zz_example_rdrecords10
	SET AUTOID=NULL,
	ID=NULL,
	CINVCODE=NULL,
	IQUANTITY=NULL,
	CBATCH=NULL,
	cFree1=NULL,
	CPOSITION=NULL,
	CDEFINE22=NULL,
	CDEFINE24=NULL,
	INQUANTITY=NULL,
	IMPOIDS=NULL,
	CMOCODE=NULL,
	IMOSEQ=NULL,
	CBSYSBARCODE=NULL


	--主表ID、仓库编码、单据日期、单据号、获得供应商、采购订单号、税率、汇率、币种、首付款协议编码、
	declare @id int
	
	declare @cdepcode varchar(50)
	set @cdepcode='0704'

	exec zz_get_rd_max_id @id output
	
	update zz_example_rdrecord10 set ID=@id,
											CWHCODE=@warehouse,
											DDATE=convert(varchar(100),getdate(),23),
											CCODE=@djh,
											CDEPCODE=@cdepcode,
											CMAKER='demo',
											DNMAKETIME=GETDATE(),
											CSYSBARCODE='||st10|'+@djh

	declare @autoid int
	exec zz_get_rd_max_autoid @autoid output


	UPDATE zz_example_rdrecords10
	SET AUTOID=@autoid,
	ID=@id,
	CINVCODE=@cinvcode,
	IQUANTITY=@iquantity,
	CPOSITION=@position,
	cFree1 = @free1,
	CDEFINE22=NULL,
	CDEFINE24=NULL,
	INQUANTITY=NULL,
	IMOSEQ=NULL,
	CBSYSBARCODE='||st10|'+ @djh +'|1'
		

	--插入正式表
	--表头
	insert into rdrecord10(ID, bRdFlag, cVouchType, cBusType, cSource, cBusCode, cWhCode, dDate, cCode, cRdCode, cDepCode, cPersonCode, cPTCode, cSTCode, cCusCode, cVenCode, cOrderCode, cARVCode, cBillCode, cDLCode, cProBatch, cHandler, cMemo, bTransFlag, cAccounter, cMaker, cDefine1, cDefine2, cDefine3, cDefine4, cDefine5, cDefine6, cDefine7, cDefine8, cDefine9, cDefine10, dKeepDate, dVeriDate, bpufirst, biafirst, iMQuantity, dARVDate, cChkCode, dChkDate, cChkPerson, VT_ID, bIsSTQc, cDefine11, cDefine12, cDefine13, cDefine14, cDefine15, cDefine16, cMPoCode, gspcheck, ipurorderid, iproorderid, iExchRate, cExch_Name, bOMFirst, bFromPreYear, bIsLsQuery, bIsComplement, iDiscountTaxType, ireturncount, iverifystate, iswfcontrolled, cModifyPerson, dModifyDate, dnmaketime, dnmodifytime, dnverifytime, bredvouch, iFlowId, cPZID, cSourceLs, cSourceCodeLs, iPrintCount, csysbarcode, cCurrentAuditor, outid)
	select ID, bRdFlag, cVouchType, cBusType, cSource, cBusCode, CWHCODE, dDate, cCode, cRdCode, cDepCode, cPersonCode, cPTCode, cSTCode, cCusCode, cVenCode, cOrderCode, cARVCode, cBillCode, cDLCode, cProBatch, cHandler, cMemo, bTransFlag, cAccounter, cMaker, cDefine1, cDefine2, cDefine3, cDefine4, cDefine5, cDefine6, cDefine7, cDefine8, cDefine9, cDefine10, dKeepDate, dVeriDate, bpufirst, biafirst, iMQuantity, dARVDate, cChkCode, dChkDate, cChkPerson, VT_ID, bIsSTQc, cDefine11, cDefine12, cDefine13, cDefine14, cDefine15, cDefine16, cMPoCode, gspcheck, ipurorderid, iproorderid, iExchRate, cExch_Name, bOMFirst, bFromPreYear, bIsLsQuery, bIsComplement, iDiscountTaxType, ireturncount, iverifystate, iswfcontrolled, cModifyPerson, dModifyDate, dnmaketime, dnmodifytime, dnverifytime, bredvouch, iFlowId, cPZID, cSourceLs, cSourceCodeLs, iPrintCount, csysbarcode, cCurrentAuditor, outid
	from zz_example_rdrecord10

	------表体
	insert into rdrecords10(AutoID, ID, cInvCode, iNum, iQuantity, iUnitCost, iPrice, iAPrice, iPUnitCost, iPPrice, cBatch, cVouchCode, cInVouchCode, cinvouchtype, iSOutQuantity, iSOutNum, cFree1, cFree2, iFlag, iFNum, iFQuantity, dVDate, cPosition, cDefine22, cDefine23, cDefine24, cDefine25, cDefine26, cDefine27, cItem_class, cItemCode, cName, cItemCName, cFree3, cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, cBarCode, iNQuantity, iNNum, cAssUnit, dMadeDate, iMassDate, cDefine28, cDefine29, cDefine30, cDefine31, cDefine32, cDefine33, cDefine34, cDefine35, cDefine36, cDefine37, iMPoIds, iCheckIds, cBVencode, bGsp, cGspState, cCheckCode, iCheckIdBaks, cRejectCode, iRejectIds, cCheckPersonCode, dCheckDate, cMassUnit, cMoLotCode, bChecked, bRelated, cmworkcentercode, bLPUseFree, iRSRowNO, iOriTrackID, coritracktype, cbaccounter, dbKeepDate, bCosting, bVMIUsed, iVMISettleQuantity, iVMISettleNum, cvmivencode, iInvSNCount, cwhpersoncode, cwhpersonname, cserviceoid, cbserviceoid, iinvexchrate, cmocode, imoseq, iopseq, copdesc, strContractGUID, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cciqbookcode, iBondedSumQty, productinids, iorderdid, iordertype, iordercode, iorderseq, isodid, isotype, csocode, isoseq, cBatchProperty1, cBatchProperty2, cBatchProperty3, cBatchProperty4, cBatchProperty5, cBatchProperty6, cBatchProperty7, cBatchProperty8, cBatchProperty9, cBatchProperty10, cbMemo, irowno, strowguid, cservicecode, ipreuseqty, ipreuseinum, OutCopiedQuantity, cbsysbarcode, cplanlotcode, bmergecheck, imergecheckautoid, iposflag, iorderdetailid, body_outid)
	select AutoID, ID, cInvCode, iNum, iQuantity, iUnitCost, iPrice, iAPrice, iPUnitCost, iPPrice, cBatch, cVouchCode, cInVouchCode, cinvouchtype, iSOutQuantity, iSOutNum, cFree1, cFree2, iFlag, iFNum, iFQuantity, dVDate, cPosition, cDefine22, cDefine23, cDefine24, cDefine25, cDefine26, cDefine27, cItem_class, cItemCode, cName, cItemCName, cFree3, cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, cBarCode, iNQuantity, iNNum, cAssUnit, dMadeDate, iMassDate, cDefine28, cDefine29, cDefine30, cDefine31, cDefine32, cDefine33, cDefine34, cDefine35, cDefine36, cDefine37, iMPoIds, iCheckIds, cBVencode, bGsp, cGspState, cCheckCode, iCheckIdBaks, cRejectCode, iRejectIds, cCheckPersonCode, dCheckDate, cMassUnit, cMoLotCode, bChecked, bRelated, cmworkcentercode, bLPUseFree, iRSRowNO, iOriTrackID, coritracktype, cbaccounter, dbKeepDate, bCosting, bVMIUsed, iVMISettleQuantity, iVMISettleNum, cvmivencode, iInvSNCount, cwhpersoncode, cwhpersonname, cserviceoid, cbserviceoid, iinvexchrate, cmocode, imoseq, iopseq, copdesc, strContractGUID, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cciqbookcode, iBondedSumQty, productinids, iorderdid, iordertype, iordercode, iorderseq, isodid, isotype, csocode, isoseq, cBatchProperty1, cBatchProperty2, cBatchProperty3, cBatchProperty4, cBatchProperty5, cBatchProperty6, cBatchProperty7, cBatchProperty8, cBatchProperty9, cBatchProperty10, cbMemo, irowno, strowguid, cservicecode, ipreuseqty, ipreuseinum, OutCopiedQuantity, cbsysbarcode, cplanlotcode, bmergecheck, imergecheckautoid, iposflag, iorderdetailid, body_outid
	from zz_example_rdrecords10

	--条码单据号、状态变更（1）


	--修改现存量
	declare @SCMCount int,@itemid int 
	declare @nCount int

	if( isnull(@free1,'')='')
	begin
		--无自由项
					---------------------------------------------------------------------------------------------
					select @SCMCount=count(*) from  SCM_Item where cinvcode=@cinvcode
					if @SCMCount=0
					begin 
					insert into SCM_Item (cInvCode) values (@cinvcode)
					end 
 
					select @itemid=id from SCM_Item where cinvcode=@cinvcode	
	
					select @nCount=count(*) from CurrentStock where cWhCode=@warehouse and cInvCode=@cinvcode  
					if @nCount=0 
					begin 
					insert into CurrentStock (  
												cWhCode,itemid,cInvCode,--物料编码
												iquantity,dvDate,dMdate,iMassDate,cMassUnit,iSodid
					)
					values	  (
												@warehouse,@itemid, 
												@cinvcode,--物料编码
												@iquantity,null,null,null,null,''
					) 
					end 
					else
					begin
					update CurrentStock set iquantity=isnull(iquantity,0)+(@iquantity)
					where  cWhCode=@warehouse and cInvCode=@cinvcode  
					end
					---------------------------------------------------------------------------------------------
	end		
	else 
	begin
		--有自由项
					---------------------------------------------------------------------------------------------
					select @SCMCount=count(*) from  SCM_Item where cinvcode=@cinvcode and cFree1=@free1
					if @SCMCount=0
					begin 
					insert into SCM_Item (cInvCode,cFree1) values (@cinvcode,@free1)
					end 
 
					select @itemid=id from SCM_Item where cinvcode=@cinvcode and cFree1=@free1	
	
					select @nCount=count(*) from CurrentStock where cWhCode=@warehouse and cInvCode=@cinvcode and cFree1=@free1 
					if @nCount=0 
					begin 
					insert into CurrentStock (  
												cWhCode,itemid,
												cInvCode,cFree1,--物料编码
												iquantity,dvDate,dMdate,iMassDate,cMassUnit,iSodid
					)
					values	  (
												@warehouse,@itemid, 
												@cinvcode,@free1,--物料编码
												@iquantity,null,null,null,null,''
					) 
					end 
					else
					begin
					update CurrentStock set iquantity=isnull(iquantity,0)+(@iquantity)
					where  cWhCode=@warehouse 
						and cInvCode=@cinvcode 
						and cFree1=@free1
					end
					---------------------------------------------------------------------------------------------
	end

	--货位库存是否需要处理
	if isnull(@position,'')<>'' and @sfhwgl=1
	begin		

		update rdrecords10 set iposflag=1 where AutoID=@autoid

		insert into InvPosition(RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch,iQuantity, dDate, bRdFlag,iTrackId, iExpiratDateCalcu, cvouchtype, dVouchDate,cFree1)
		select b.autoid,a.id,a.cwhcode,b.cPosition,b.cinvcode,b.cbatch,b.iquantity,a.ddate,1,0,0,'10',a.ddate,cFree1
		from rdrecord10 a left join rdrecords10 b on a.id=b.id
		where a.ccode=@djh

		--修改货位库存 需立即修改  未完成
		declare @ips int
		select @ips = count(1) from InvPositionSum  
		where cWhCode=@warehouse 
				and cInvCode=@cinvcode 
				and cPosCode=@position 
				and isnull(cFree1,'')=isnull(@free1,'')

		if (@ips>0)
		begin
				update InvPositionSum 
				set iQuantity = iQuantity+@iquantity 
				where cWhCode=@warehouse 
					and cInvCode=@cinvcode 
					and cPosCode=@position 
					and isnull(cFree1,'')=isnull(@free1,'')
		end
		else
		begin 
			--select * from InvPositionSum
			insert into InvPositionSum(cWhCode,cPosCode,cInvCode,iQuantity,cFree1)
			values(@warehouse,@position,@cinvcode,@iquantity,isnull(@free1,''))
		end




	end
	else if @sfhwgl=0
	begin
		update rdrecords10 set iposflag=0 where AutoID=@autoid
	end 

	--回写条码档案表
	update UF_ext_QRCODE 
	set statu=1,
		cWhCodeIn=@warehouse,
		cPosCodeIn=@position,
		rdincode = @djh
	where id = @tmid


	--回写ID号记录
	exec zz_up_ua_identity_rd @cacc_id

	--执行存货核算存储过程
	exec IA_SP_WriteUnAccountVouchForST Null, '10' 

	set @ccode=@djh
	
end
else
begin
	set @ccode='没有生成产成品入库单'
end

 commit transaction


GO

