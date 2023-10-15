const jwt = require("jsonwebtoken");

const auth = async (req, res, next) => {
  try {
    const token = req.cookies.jsonToken;

    const verify = jwt.verify(token, "secret");

    next();
  } catch (err) {
    console.log(err);

    res.redirect("/teacher/login");
  }
};

module.exports = auth;
