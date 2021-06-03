from pyrfc import Connection
from sap_connection import get_sap_logon_params

class SapGLService(object):
    def __init__(self, system_id):
        self.system_id = system_id
        self.sap_connection = Connection(**get_sap_logon_params(system_id))

    def get_bs_balances(self, cocd, fiscalyear, fiscalperiod):
        sap = self.sap_connection
        rv = sap.call("Z_BS_BALANCES",
                     COMPANYCODE = cocd,
                     FISCALYEAR = fiscalyear,
                     FISCALPERIOD = fiscalperiod)

        return rv


if __name__ == '__main__':
    gl_service = SapGLService("D01")
    rv = gl_service.get_bs_balances("Z900", "2020", "10")
    print(rv)