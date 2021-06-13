FUNCTION Z_BS_BALANCES.
*"----------------------------------------------------------------------
*"*"Local Interface:
*"  IMPORTING
*"     VALUE(COMPANYCODE) TYPE  ZGLACCBALANCE-COMPCODE
*"     VALUE(FISCALYEAR) TYPE  ZGLACCBALANCE-FISYEAR
*"     VALUE(FISCALPERIOD) TYPE  ZGLACCBALANCE-PERIOD
*"  TABLES
*"      ACC_BALANCES STRUCTURE  ZFSBALANCE
*"      FS_BALANCES STRUCTURE  ZFSBALANCESUM
*"----------------------------------------------------------------------
data: lt_setvalues type table of rgsb4,
        ls_setvalues like line of lt_setvalues.

  data: lt_all like standard table of zglaccbalance with header line.   " balances for all acocunts

  data: lt_ret     like standard table of zfsbalance with header line,      " æ¥è¡¨é¡¹éé¢
        lt_sum     like standard table of zfsbalancesum with header line,   " æ¥è¡¨é¡¹éé¢æ±æ»
        lt_sumtemp like standard table of lt_sum with header line.

  call function 'Z_BAPI_GLACCPERIODBALANCES'
    exporting
      companycode  = companycode
      fiscalyear   = fiscalyear
      fiscalperiod = fiscalperiod
    tables
      acc_balances = lt_all.

  " 获取
  loop at lt_all.
    move-corresponding lt_all to lt_ret.
    append lt_ret.
    clear: lt_all, lt_ret.
  endloop.

  " 获取报表项的科目
  call function 'G_SET_GET_ALL_VALUES'
    exporting
      client        = sy-mandt
      setnr         = 'ZBS'
      table         = 'SKB1'
      class         = '0000'
      fieldname     = 'SAKNR'
    tables
      set_values    = lt_setvalues
    exceptions
      set_not_found = 1
      others        = 2.

  " 去掉0000
  loop at lt_setvalues into ls_setvalues.
    replace '0000' in ls_setvalues-setnr with ''.
    modify lt_setvalues from ls_setvalues.
    clear ls_setvalues.
  endloop.

  loop at lt_ret.
    loop at lt_setvalues into ls_setvalues.
      if lt_ret-glaccount between ls_setvalues-from and ls_setvalues-to.
        lt_ret-fsitem = ls_setvalues-setnr.
        modify lt_ret.
      endif.
      clear ls_setvalues.
    endloop.
  endloop.

  " 汇总
  loop at lt_ret.
    move-corresponding lt_ret to lt_sumtemp.
    append lt_sumtemp.
    clear: lt_ret, lt_sumtemp.
  endloop.
  sort lt_sumtemp by fsitem.
  loop at lt_sumtemp.
    collect lt_sumtemp into lt_sum.
    clear: lt_sumtemp, lt_sum.
  endloop.

  acc_balances[] = lt_ret[].
  fs_balances[] = lt_sum[].

ENDFUNCTION.