import pandas as pd
from flask import Flask, request, jsonify
from SAP_Service.gl_service import SapGLService

app = Flask(__name__)
app.config["JSON_SORT_KEYS"] = False

@app.route("/")
def index():
    return "Home page"


@app.route("/sap/bal")
def acc_glbalances():
    cocd = request.args.get("cocd")
    year = request.args.get("year")
    period = request.args.get("period")

    sap = SapGLService("D01");
    balances = sap.get_bs_balances(cocd, year, period)

    return jsonify({"values" : balances["ACC_BALANCES"]})

if __name__ == "__main__":
    app.run(port=8000)