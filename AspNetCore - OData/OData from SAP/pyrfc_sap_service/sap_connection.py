from configparser import ConfigParser

CONFIG_FILE = "sapnwrfc.cfg"

def get_sap_logon_params(section_name):
    """
    get SAP logon parameters from sapnwrfc.cfg file
    """

    config = ConfigParser()
    config.read(CONFIG_FILE)

    # logon_params is of type OrderedDict
    logon_params = config._sections[section_name]

    return logon_params


# if __name__ == '__main__':
#     sap_params = get_sap_logon_params("D01")
#     print(sap_params)