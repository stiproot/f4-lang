
usr_qry: "code an io workflow"


agnts:
    - coder
    - validator


tools:
    - io
    - shell
    - compiler


give validator two fns to invoke:
    - valid
    - invalid


coder -!> generate code
coder -> validator(code)
validator -!> compile code(code)
validator -valid?> valid()/invalid()
